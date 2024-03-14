using AddressBook.Locations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace AddressBook
{
   public class AddressBookDataSeederContributor : IDataSeedContributor, ITransientDependency
    {
        private readonly IRepository<Location,Guid> _locationRepository;

        public AddressBookDataSeederContributor( IRepository<Location, Guid> locationRepository)
        {
            _locationRepository = locationRepository;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (await _locationRepository.GetCountAsync() <= 0 )
            {
                await _locationRepository.InsertAsync(
                    new Location
                    {
                        Latitude = 20.5937,
                        Longitude = 78.9629,
                        Address = AddressLoco.India,
                        Name = "Arun",
                        
                    },
                    autoSave: true
                    );
                await _locationRepository.InsertAsync(
                  new Location
                  {
                      Latitude = 37.0902,
                      Longitude = 95.7129,
                      Address = AddressLoco.America,
                      Name = "Frank",
                      
                  },
                  autoSave: true
                  );
            }
        }
    }
}
