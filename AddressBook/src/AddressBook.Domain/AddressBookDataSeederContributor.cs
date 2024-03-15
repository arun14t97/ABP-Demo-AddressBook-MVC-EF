using AddressBook.AddressF;
using AddressBook.Locations;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.IO;
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
        private readonly IAddressRepository _addressRepository;
        private readonly AddressManager _addressManager;

        public AddressBookDataSeederContributor( IRepository<Location, Guid> locationRepository, IAddressRepository addressRepository,
        AddressManager addressManager)
        {
            _locationRepository = locationRepository;
            _addressRepository = addressRepository;
            _addressManager = addressManager;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (await _locationRepository.GetCountAsync() <= 0)
            {
                return;
            }
            // ADDED SEED DATA FOR AUTHORS


            var country1 = await _addressRepository.InsertAsync(

             await _addressManager.CreateAsync(
                     "street1",
                     "city1",
                     "state1",
                     "postalCode1",
                     "country1"
                 )
             );

            var country2 = await _addressRepository.InsertAsync(
                await _addressManager.CreateAsync(
                   "street2",
                    "city2",
                    "state2",
                    "postalCode2",
                    "country2"
                )
            );


            await _locationRepository.InsertAsync(
                    new Location
                    {
                        AddressId = country1.Id, //set the address
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
                      AddressId = country2.Id, //set the address
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
