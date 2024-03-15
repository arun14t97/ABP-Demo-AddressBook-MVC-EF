using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace AddressBook.Locations
{
    public class LocationDto : AuditedEntityDto<Guid>
    {
        public Guid AddressId { get; set; }
        public string AddressName { get; set; }

        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Name { get; set; }
        public AddressLoco Address { get; set; }
    }
}
