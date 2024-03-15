using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace AddressBook.Locations
{
    public class AddressLookupDto : EntityDto<Guid>
    {
        public string Country { get; set; }
    }
}
