using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace AddressBook.AddressF
{
    public interface IAddressAppService : IApplicationService
    {
        Task<AddressDto> GetAsync(Guid id);

        Task<PagedResultDto<AddressDto>> GetListAsync(GetAddressListDto input);

        Task<AddressDto> CreateAsync(CreateAddressDto input);

        Task UpdateAsync(Guid id, UpdateAddressDto input);

        Task DeleteAsync(Guid id);
    }
}
