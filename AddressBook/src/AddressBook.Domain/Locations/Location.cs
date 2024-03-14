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
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Name { get; set; }
        public AddressLoco Address { get; set; }

       
    }
    

}
