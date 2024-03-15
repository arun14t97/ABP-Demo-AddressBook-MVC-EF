using AddressBook.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

using System.Linq.Dynamic.Core;



namespace AddressBook.AddressF
{
    public class EfCoreAddressRepository : EfCoreRepository<AddressBookDbContext, Address, Guid>,
        IAddressRepository
    {
        public EfCoreAddressRepository(IDbContextProvider<AddressBookDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<Address> FindByNameAsync(string country)
        {
            var dbSet = await GetDbSetAsync();
            return await dbSet.FirstOrDefaultAsync(address => address.Country == country);
        }

        public async Task<List<Address>> GetListAsync(int skipCount, int maxResultCount, string sorting, string filter = null)
        {
            var dbSet = await GetDbSetAsync();
            return await dbSet
                .WhereIf(
                    !filter.IsNullOrWhiteSpace(),
                    address => address.Country.Contains(filter)
                    )
                .OrderBy(sorting)
                .Skip(skipCount)
                .Take(maxResultCount)
                .ToListAsync();
        }
    }
}
