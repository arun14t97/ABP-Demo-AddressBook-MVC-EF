using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AddressBook.AddressF
{
    public class CreateAddressDto
    {
        [Required]
        [StringLength(AddressConsts.MaxNameLength)]
        public string Street { get; set; } = string.Empty;
        [Required]
        public string City { get; set; } = string.Empty;
        [Required]
        public string State { get; set; } = string.Empty;
        [Required]
        public string PostalCode { get; set; } = string.Empty;
        [Required]
        public string? Country { get; set; } = string.Empty;
    }
}
