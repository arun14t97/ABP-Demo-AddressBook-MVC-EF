using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace AddressBook.Locations
{
    public class LocationDto : AuditedEntityDto<Guid>
    {
        public Guid AddressId { get; set; }
        public string AddressCountry { get; set; } = string.Empty;
        public string AddressStreet { get; set; }
        public string AddressCity { get; set; }
        public string AddressState { get; set; }
        public string AddressPostalCode { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Name { get; set; } = string.Empty;
        public AddressLoco Address { get; set; }
    }
}
