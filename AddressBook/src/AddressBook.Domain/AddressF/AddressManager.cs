using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Services;

namespace AddressBook.AddressF
{
    public class AddressManager : DomainService
    {
        private readonly IAddressRepository _addressRepository;

        public AddressManager(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }
        public async Task<Address> CreateAsync(
            string street,
            string city,
            string state,
            string postalCode,
            string country)
        {
            Check.NotNullOrWhiteSpace(country, nameof(country));
            var existingAddress = await _addressRepository.FindByNameAsync(country);
            if (existingAddress != null) {
                throw new AddressAlreadyExistsException(country);

            }
            return new Address(
                GuidGenerator.Create(),
                street,
                city,
                state,
                postalCode,
                country
                );
        }

        public async Task ChangeNameAsync(
            Address address,
            string newCountry)
        {
            Check.NotNull(address, nameof(address));
            Check.NotNullOrWhiteSpace(newCountry, nameof(newCountry));

            var existingAddress = await _addressRepository.FindByNameAsync(newCountry);
            if (existingAddress != null && existingAddress.Id != address.Id)
            {
                throw new AddressAlreadyExistsException(newCountry);
            }
            address.ChangeCountry(newCountry);
            }
    }
}
