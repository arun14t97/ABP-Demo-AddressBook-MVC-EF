using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using AddressBook.AddressF;
using AutoMapper.Internal.Mappers;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;

namespace AddressBook.Web.Pages.AddressF;

public class EditModalModel : AddressBookPageModel
{
    [BindProperty]
    public EditAddressViewModel Address{ get; set; }

    private readonly IAddressAppService _addressAppService;

    public EditModalModel(IAddressAppService addressAppService)
    {
        _addressAppService = addressAppService;
    }

    public async Task OnGetAsync(Guid id)
    {
        var addressDto = await _addressAppService.GetAsync(id);
        Address = ObjectMapper.Map<AddressDto, EditAddressViewModel>(addressDto);
    }

    public async Task<IActionResult> OnPostAsync()
    {
        await _addressAppService.UpdateAsync(
            Address.Id,
            ObjectMapper.Map<EditAddressViewModel, UpdateAddressDto>(Address)
        );

        return NoContent();
    }

    public class EditAddressViewModel
    {
        [HiddenInput]
        public Guid Id { get; set; }

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
        public string Country { get; set; } = string.Empty;
    }
}
