using System;
using System.Threading.Tasks;
using Shouldly;
using Volo.Abp.Modularity;
using Xunit;

namespace AddressBook.AddressF;

public abstract class AddressAppService_Tests<TStartupModule> : AddressBookApplicationTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{
    private readonly IAddressAppService _addressAppService;

    protected AddressAppService_Tests()
    {
        _addressAppService = GetRequiredService<IAddressAppService>();
    }

    [Fact]
    public async Task Should_Get_All_Address_Without_Any_Filter()
    {
        var result = await _addressAppService.GetListAsync(new GetAddressListDto());

        result.TotalCount.ShouldBeGreaterThanOrEqualTo(2);
        result.Items.ShouldContain(address => address.Country == "country1");
        result.Items.ShouldContain(address => address.Country == "country2");
    }

    [Fact]
    public async Task Should_Get_Filtered_Address()
    {
        var result = await _addressAppService.GetListAsync(
            new GetAddressListDto { Filter = "1" });

        result.TotalCount.ShouldBeGreaterThanOrEqualTo(1);
        result.Items.ShouldContain(address => address.Country == "country1");
        result.Items.ShouldNotContain(address => address.Country == "country2");
    }

    [Fact]
    public async Task Should_Create_A_New_Address()
    {
        var addressDto = await _addressAppService.CreateAsync(
            new CreateAddressDto
            {
               Street = "street3",
                City = "city3",
                State = "state3",
                PostalCode = "postalCode3",
               Country =  "country3"
            }
        );

        addressDto.Id.ShouldNotBe(Guid.Empty);
        addressDto.Country.ShouldBe("country3");
    }

    [Fact]
    public async Task Should_Not_Allow_To_Create_Duplicate_Address()
    {
        await Assert.ThrowsAsync<AddressAlreadyExistsException>(async () =>
        {
            await _addressAppService.CreateAsync(
                new CreateAddressDto
                {
                    Street = "street1",
                    City = "city1",
                    State = "state1",
                    PostalCode = "postalCode1",
                    Country = "country1"
                }
            );
        });
    }

    //TODO: Test other methods...
}
