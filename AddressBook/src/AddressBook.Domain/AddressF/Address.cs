using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace AddressBook.AddressF
{
    public class Address : FullAuditedAggregateRoot<Guid>
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; private set; }


        private Address()
        {
            /* This constructor is for deserialization / ORM purpose */
        }

        internal Address(
            Guid id,
            string street,
            string city,
            string state,
            string postalCode,
            string? country= null)
            :base(id)
        {
            Street = street;
            City = city;
            State = state;
            PostalCode = postalCode;
            SetCountry(country);
        }

        internal Address ChangeCountry(string country)
        {
            SetCountry(country);
            return this;
        }

        private void SetCountry(string country)
        {
            Country = Check.NotNullOrWhiteSpace(
                country,
                nameof(country),
                maxLength: AddressConsts.MaxNameLength
                );
        }
    }
}
