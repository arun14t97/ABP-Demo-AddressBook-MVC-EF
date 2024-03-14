using AddressBook.Locations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace AddressBook.Web.Pages.Locations
{
    public class CreateModalModel : AddressBookPageModel
    {
        [BindProperty]
        public CreateUpdateLocationDto Location { get; set; }
        private readonly ILocationAppService _locationAppService;
        public CreateModalModel(ILocationAppService locationAppService)
        {
            _locationAppService = locationAppService;
        }
        public void OnGet()
        {
            Location = new CreateUpdateLocationDto();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            await _locationAppService.CreateAsync(Location);
            return NoContent();
        }
    }
}
