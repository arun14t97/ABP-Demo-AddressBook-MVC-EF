using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AddressBook.AddressF;
using Shouldly;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Modularity;
using Volo.Abp.Validation;
using Xunit;

namespace AddressBook.Locations
{
    public abstract class LocationAppService_Tests<TStartupModule> : AddressBookApplicationTestBase<TStartupModule>
    where TStartupModule : IAbpModule
    {
        private readonly ILocationAppService _locationAppService;
        private readonly IAddressAppService _addressAppService;

        protected LocationAppService_Tests()
        {
            _locationAppService = GetRequiredService<ILocationAppService>();
            _addressAppService = GetRequiredService<IAddressAppService>();
        }

        [Fact]
        public async Task Should_Get_List_Of_Locations()
        {
            //Act
            var result = await _locationAppService.GetListAsync(
                new PagedAndSortedResultRequestDto()
            );

            //Assert
            result.TotalCount.ShouldBeGreaterThan(0);
            result.Items.ShouldContain(b => b.Name == "x" && b.AddressCountry == "country1");
        }

        [Fact]
        public async Task Should_Create_A_Valid_Location()
        {
            var addressF = await _addressAppService.GetListAsync(new GetAddressListDto());
            var firstAddress = addressF.Items.First();
            //Act
            var result = await _locationAppService.CreateAsync(
                new CreateUpdateLocationDto
                {
                    AddressId = firstAddress.Id,
                    Latitude = 22.3333,
                    Longitude = 33.4444,
                    Name = "z",
                    Address = AddressLoco.America
                }
            );

            //Assert
            result.Id.ShouldNotBe(Guid.Empty);
            result.Name.ShouldBe("z");
        }

        [Fact]
        public async Task Should_Not_Create_A_Location_Without_Name()
        {
            var exception = await Assert.ThrowsAsync<AbpValidationException>(async () =>
            {
                await _locationAppService.CreateAsync(
                    new CreateUpdateLocationDto
                    {
                        Latitude = 22.3333,
                        Longitude = 33.4444,
                        Name = "",
                        Address = AddressLoco.America
                    }
                );
            });

            exception.ValidationErrors
                .ShouldContain(err => err.MemberNames.Any(mem => mem == "Name"));
        }


    }
}
