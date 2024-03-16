using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace AddressBook.Locations
{
    public class Location : AuditedAggregateRoot<Guid>
    {
        public Guid AddressId { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Name { get; set; } = string.Empty;
        public AddressLoco Address { get; set; }

       

    }


}
