using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using AddressBook.AddressF;
using AutoMapper.Internal.Mappers;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;

namespace AddressBook.Web.Pages.AddressF;

public class CreateModalModel : AddressBookPageModel
{
    [BindProperty]
    public CreateAddressViewModel Address { get; set; }

    private readonly IAddressAppService _addressAppService;

    public CreateModalModel(IAddressAppService addressAppService)
    {
        _addressAppService = addressAppService;
    }

    public void OnGet()
    {
        Address = new CreateAddressViewModel();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        var dto = ObjectMapper.Map<CreateAddressViewModel, CreateAddressDto>(Address);
        await _addressAppService.CreateAsync(dto);
        return NoContent();
    }

    public class CreateAddressViewModel
    {
        [Required]
        [StringLength(AddressConsts.MaxNameLength)]
        public string Street { get; set; }
        [Required]
        [StringLength(AddressConsts.MaxNameLength)]
        public string City { get; set; }
        [Required]
        [StringLength(AddressConsts.MaxNameLength)]
        public string State { get; set; }
        [Required]
        [StringLength(AddressConsts.MaxNameLength)]
        public string PostalCode { get; set; }
        [Required]
        [StringLength(AddressConsts.MaxNameLength)]
        public string? Country { get; set; } = string.Empty;
    }
}
