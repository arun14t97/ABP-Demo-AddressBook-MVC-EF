using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;

namespace AddressBook.AddressF
{
    public class AddressAlreadyExistsException : BusinessException
    {
        public AddressAlreadyExistsException(string country)
        : base(AddressBookDomainErrorCodes.AddressAlreadyExists)
        {
            WithData("country", country);
        }
    }
}
