﻿using AddressBook.AddressF;
using AddressBook.Permissions;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;

using System.Linq.Dynamic.Core;



namespace AddressBook.Locations
{
    [Authorize(AddressBookPermissions.Locations.Default)]
    public class LocationAppService :
        CrudAppService<
            Location,
            LocationDto,
            Guid,
            PagedAndSortedResultRequestDto,
            CreateUpdateLocationDto>,
        ILocationAppService
    {
        private readonly IAddressRepository _addressRepository;
        public LocationAppService(IRepository<Location, Guid> repository, IAddressRepository addressRepository) : base(repository)
        {
            _addressRepository = addressRepository;
            GetPolicyName = AddressBookPermissions.Locations.Default;
            GetListPolicyName = AddressBookPermissions.Locations.Default;
            CreatePolicyName = AddressBookPermissions.Locations.Create;
            UpdatePolicyName = AddressBookPermissions.Locations.Edit;
            DeletePolicyName = AddressBookPermissions.Locations.Delete;
        }
        public override async Task<LocationDto> GetAsync(Guid id)
        {
            //Get the IQueryable<Location> from the repository
            var queryable = await Repository.GetQueryableAsync();

            //Prepare a query to join locations and addressF
            var query = from location in queryable
                        join address in await _addressRepository.GetQueryableAsync() on location.AddressId equals address.Id
                        where location.Id == id
                        select new { location, address };

            //Execute the query and get the location with address
            var queryResult = await AsyncExecuter.FirstOrDefaultAsync(query);
            if (queryResult == null)
            {
                throw new EntityNotFoundException(typeof(Location), id);
            }

            var locationDto = ObjectMapper.Map<Location, LocationDto>(queryResult.location);
            locationDto.AddressCountry = queryResult.address.Country;
            return locationDto;
        }

        public override async Task<PagedResultDto<LocationDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            //Get the IQueryable<Location> from the repository
            var queryable = await Repository.GetQueryableAsync();

            //Prepare a query to join locations and addressF
            var query = from location in queryable
                        join address in await _addressRepository.GetQueryableAsync() on location.AddressId equals address.Id
                        select new { location, address };

            //Paging
            query = query
                .OrderBy(NormalizeSorting(input.Sorting))
                .Skip(input.SkipCount)
                .Take(input.MaxResultCount);

            //Execute the query and get a list
            var queryResult = await AsyncExecuter.ToListAsync(query);

            //Convert the query result to a list of BookDto objects
            var bookDtos = queryResult.Select(x =>
            {
                var bookDto = ObjectMapper.Map<Book, BookDto>(x.book);
                bookDto.AuthorName = x.author.Name;
                return bookDto;
            }).ToList();

            //Get the total count with another query
            var totalCount = await Repository.GetCountAsync();

            return new PagedResultDto<BookDto>(
                totalCount,
                bookDtos
            );
        }

        public async Task<ListResultDto<AuthorLookupDto>> GetAuthorLookupAsync()
        {
            var authors = await _authorRepository.GetListAsync();

            return new ListResultDto<AuthorLookupDto>(
                ObjectMapper.Map<List<Author>, List<AuthorLookupDto>>(authors)
            );
        }

        private static string NormalizeSorting(string sorting)
        {
            if (sorting.IsNullOrEmpty())
            {
                return $"book.{nameof(Book.Name)}";
            }

            if (sorting.Contains("authorName", StringComparison.OrdinalIgnoreCase))
            {
                return sorting.Replace(
                    "authorName",
                    "author.Name",
                    StringComparison.OrdinalIgnoreCase
                );
            }

            return $"book.{sorting}";
        }
    }
}
