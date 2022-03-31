using Dale.WebSite.Apis;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Dale.WebSite.Pages.Customer
{
    public class CreateModel : PageModel
    {
        public CreateModel(IDaleClientCustomer daleClient) => _daleClient = daleClient;

        [BindProperty]
        public Models.CustomerDto CustomerDTO { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _daleClient.CreateCustomer(CustomerDTO);

            return RedirectToPage("./Index");
        }

        private readonly IDaleClientCustomer _daleClient;
    }
}