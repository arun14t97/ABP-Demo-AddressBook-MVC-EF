using AddressBook.AddressF;
using AddressBook.Locations;
using AutoMapper;

namespace AddressBook.Web;

public class AddressBookWebAutoMapperProfile : Profile
{
    public AddressBookWebAutoMapperProfile()
    {
        //Define your AutoMapper configuration here for the Web project.
        CreateMap<LocationDto,CreateUpdateLocationDto>();
        // ADD a NEW MAPPING
        CreateMap<Pages.AddressF.CreateModalModel.CreateAddressViewModel,
                    CreateAddressDto>();
        // ADD THESE NEW MAPPINGS
        CreateMap<AddressDto, Pages.AddressF.EditModalModel.EditAddressViewModel>();
        CreateMap<Pages.AddressF.EditModalModel.EditAddressViewModel,
                    UpdateAddressDto>();

        CreateMap<Pages.Locations.CreateModalModel.CreateLocationViewModel, CreateUpdateLocationDto>();
        CreateMap<LocationDto, Pages.Locations.EditModalModel.EditLocationViewModel>();
        CreateMap<Pages.Locations.EditModalModel.EditLocationViewModel, CreateUpdateLocationDto>();

    }
}
