﻿using AddressBook.AddressF;
using AddressBook.Locations;
using AutoMapper;

namespace AddressBook;

public class AddressBookApplicationAutoMapperProfile : Profile
{
    public AddressBookApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */
        CreateMap <Location, LocationDto> ();
        CreateMap <CreateUpdateLocationDto, Location> ();
        CreateMap<Address, AddressDto>();
        CreateMap<Address, AddressLookupDto>();

    }
}
