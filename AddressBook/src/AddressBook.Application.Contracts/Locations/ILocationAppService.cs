using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace AddressBook.Locations
{
    public  interface ILocationAppService : 
        ICrudAppService< //Defines CRUD methods
        LocationDto, //Used to show books
        Guid, //Primary key of the book entity
        PagedAndSortedResultRequestDto, //Used for paging/sorting
        CreateUpdateLocationDto> //Used to create/update a book
    {
    }
}
