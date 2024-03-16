using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AddressBook.Locations
{
    public class CreateUpdateLocationDto
    {

        public Guid AddressId { get; set; }
        [Required]
        public double Latitude { get; set; }
        [Required]
        public double Longitude { get; set; }
        [Required]
        [StringLength(128)]
        public string Name { get; set; } = string.Empty;
        [Required]
        public AddressLoco Address { get; set; } = AddressLoco.Undefined;

       
    }
}
