using System;
using System.Threading.Tasks;
using AddressBook.AddressF;
using AddressBook.Locations;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace AddressBook;

public class AddressBookDataSeederContributor
    : IDataSeedContributor, ITransientDependency
{
    private readonly IRepository<Location, Guid> _locationRepository;
    private readonly IAddressRepository _addressRepository;
    private readonly AddressManager _addressManager;

    public AddressBookDataSeederContributor(
        IRepository<Location, Guid> locationRepository,
        IAddressRepository addressRepository,
        AddressManager addressManager)
    {
        _locationRepository = locationRepository;
        _addressRepository = addressRepository;
        _addressManager = addressManager;
    }

    public async Task SeedAsync(DataSeedContext context)
    {
        if (await _locationRepository.GetCountAsync() > 0)
        {
            return;
        }

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
                AddressId = country1.Id, // SET THE Address
                Latitude = 22.3333,
                Longitude = 33.4444,
                Name = "x",
                Address = AddressLoco.America
            },
            autoSave: true
        );

        await _locationRepository.InsertAsync(
            new Location
            {
                AddressId = country2.Id, // SET THE Address
                Latitude = 66.7777,
                Longitude = 77.8888,
                Name = "y",
                Address = AddressLoco.India
            },
            autoSave: true
        );
    }
}
