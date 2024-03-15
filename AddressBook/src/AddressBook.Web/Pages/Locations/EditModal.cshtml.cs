using System;
using System.Threading.Tasks;
using AddressBook.Locations;
using AutoMapper.Internal.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace AddressBook.Web.Pages.Locations;

public class EditModalModel : AddressBookPageModel
{
    [HiddenInput]
    [BindProperty(SupportsGet = true)]
    public Guid Id { get; set; }

    [BindProperty]
    public CreateUpdateLocationDto Location { get; set; }

    private readonly ILocationAppService _locationAppService;

    public EditModalModel(ILocationAppService locationAppService)
    {
        _locationAppService = locationAppService;
    }

    public async Task OnGetAsync()
    {
        var locationDto = await _locationAppService.GetAsync(Id);
        Location = ObjectMapper.Map<LocationDto, CreateUpdateLocationDto>(locationDto);
    }

    public async Task<IActionResult> OnPostAsync()
    {
        await _locationAppService.UpdateAsync(Id, Location);
        return NoContent();
    }
}
