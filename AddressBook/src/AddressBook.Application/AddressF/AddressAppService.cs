using AddressBook.Permissions;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;

namespace AddressBook.AddressF
{
    [Authorize(AddressBookPermissions.AddressF.Default)]
    public class AddressAppService : AddressBookAppService, IAddressAppService
    {
        private readonly IAddressRepository _addressRepository;
        private readonly AddressManager _addressManager;

        public AddressAppService(
            IAddressRepository addressRepository,
            AddressManager addressManager)
        {
            _addressRepository = addressRepository;
            _addressManager = addressManager;
        }

        //...SERVICE METHODS WILL COME HERE...

        public async Task<AddressDto> GetAsync(Guid id)
        {
            var address = await _addressRepository.GetAsync(id);
            return ObjectMapper.Map<Address, AddressDto>(address);
        }

        public async Task<PagedResultDto<AddressDto>> GetListAsync(GetAddressListDto input)
        {
            if (input.Sorting.IsNullOrWhiteSpace())
            {
                input.Sorting = nameof(Address.Country);
            }

            var addressF = await _addressRepository.GetListAsync(
                input.SkipCount,
                input.MaxResultCount,
                input.Sorting,
                input.Filter
            );

            var totalCount = input.Filter == null
                ? await _addressRepository.CountAsync()
                : await _addressRepository.CountAsync(
                    author => author.Country.Contains(input.Filter));

            return new PagedResultDto<AddressDto>(
                totalCount,
                ObjectMapper.Map<List<Address>, List<AddressDto>>(addressF)
            );
        }

        [Authorize(AddressBookPermissions.AddressF.Create)]
        public async Task<AddressDto> CreateAsync(CreateAddressDto input)
        {
            var address = await _addressManager.CreateAsync(
                input.Street,
                input.City,
                input.State,
                input.PostalCode,
                input.Country
            );

            await _addressRepository.InsertAsync(address);

            return ObjectMapper.Map<Address, AddressDto>(address);
        }

        [Authorize(AddressBookPermissions.AddressF.Edit)]
        public async Task UpdateAsync(Guid id, UpdateAddressDto input)
        {
            var address = await _addressRepository.GetAsync(id);

            if (address.Country != input.Country)
            {
                await _addressManager.ChangeNameAsync(address, input.Country);
            }

            address.Street = input.Street;
            address.City = input.City;
            address.State = input.State;
            address.PostalCode = input.PostalCode;

            await _addressRepository.UpdateAsync(address);
        }

        [Authorize(AddressBookPermissions.AddressF.Delete)]
        public async Task DeleteAsync(Guid id)
        {
            await _addressRepository.DeleteAsync(id);
        }

    }
}
