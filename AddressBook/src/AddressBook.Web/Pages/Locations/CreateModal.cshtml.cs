using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using AddressBook.Locations;
using AutoMapper.Internal.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;

namespace AddressBook.Web.Pages.Locations;

public class CreateModalModel : AddressBookPageModel
{
    [BindProperty]
    public CreateLocationViewModel Location { get; set; }

    public List<SelectListItem> AddressF{ get; set; }
   

    private readonly ILocationAppService _locationAppService;

    public CreateModalModel(
        ILocationAppService locationAppService)
    {
        _locationAppService = locationAppService;
    }

    public async Task OnGetAsync()
    {
        Location = new CreateLocationViewModel();

        var addressLookup = await _locationAppService.GetAddressLookupAsync();
        AddressF = addressLookup.Items
            .Select(x => new SelectListItem(x.Country, x.Id.ToString()))
            .ToList();
        
    }

    public async Task<IActionResult> OnPostAsync()
    {
        await _locationAppService.CreateAsync(
            ObjectMapper.Map<CreateLocationViewModel, CreateUpdateLocationDto>(Location)
            );
        return NoContent();
    }

    public class CreateLocationViewModel
    {

        [SelectItems(nameof(AddressF))]
        [DisplayName("Country")]

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
