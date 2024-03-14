using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AddressBook.Locations
{
    public class CreateUpdateLocationDto
    {
        [Required]
        [StringLength(128)]
        public double Latitude { get; set; }
        [Required]
        public double Longitude { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public AddressLoco Address { get; set; } = AddressLoco.Undefined;
    }
}
