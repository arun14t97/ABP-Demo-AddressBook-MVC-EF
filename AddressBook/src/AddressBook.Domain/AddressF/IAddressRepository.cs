using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace AddressBook.AddressF
{
    public interface IAddressRepository : IRepository<Address, Guid>
    {
        Task<Address> FindByNameAsync(string country);

        Task<List<Address>> GetListAsync(
            int skipCount,
            int maxResultCount,
            string sorting,
            string filter = null
        );
    }
}
