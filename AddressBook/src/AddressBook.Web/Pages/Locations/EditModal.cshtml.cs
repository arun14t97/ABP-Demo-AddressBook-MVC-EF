using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using AddressBook.Locations;
using AutoMapper.Internal.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;

namespace AddressBook.Web.Pages.Locations;

public class EditModalModel : AddressBookPageModel
{

    [BindProperty(SupportsGet = true)]
    public EditLocationViewModel Location { get; set; }

    public List<SelectListItem> AddressFCountry { get; set; }
    public List<SelectListItem> AddressFStreet { get; set; }
    public List<SelectListItem> AddressFCity { get; set; }
    public List<SelectListItem> AddressFState { get; set; }
    public List<SelectListItem> AddressFPostalCode { get; set; }


    private readonly ILocationAppService _locationAppService;

    public EditModalModel(ILocationAppService locationAppService)
    {
        _locationAppService = locationAppService;
    }

    public async Task OnGetAsync(Guid id)
    {
        var locationDto = await _locationAppService.GetAsync(id);
        Location = ObjectMapper.Map<LocationDto, EditLocationViewModel>(locationDto);

        var addressLookup = await _locationAppService.GetAddressLookupAsync();
        AddressFCountry = addressLookup.Items
            .Select(x => new SelectListItem(x.Country, x.Id.ToString()))
            .ToList();
        AddressFStreet = addressLookup.Items
            .Select(x => new SelectListItem(x.Street, x.Id.ToString()))
            .ToList();
        AddressFCity = addressLookup.Items
            .Select(x => new SelectListItem(x.City, x.Id.ToString()))
            .ToList();
        AddressFState = addressLookup.Items
            .Select(x => new SelectListItem(x.State, x.Id.ToString()))
            .ToList();
        AddressFPostalCode = addressLookup.Items
            .Select(x => new SelectListItem(x.PostalCode, x.Id.ToString()))
            .ToList();
            
    }

    public async Task<IActionResult> OnPostAsync()
    {
        await _locationAppService.UpdateAsync(Location.Id, ObjectMapper.Map<EditLocationViewModel, CreateUpdateLocationDto>(Location));
        return NoContent();
    }
    public class EditLocationViewModel
    {
        [HiddenInput]
        public Guid Id { get; set; }

        [SelectItems(nameof(AddressFCountry))]
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
