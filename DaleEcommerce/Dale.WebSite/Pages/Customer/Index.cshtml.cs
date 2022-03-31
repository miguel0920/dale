using Dale.WebSite.Apis;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Dale.WebSite.Pages.Customer
{
    public class IndexModel : PageModel
    {
        public IndexModel(IDaleClientCustomer daleClient) => _daleClient = daleClient;

        [BindProperty]
        public List<Models.CustomerDto>? CustomerDTO { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            CustomerDTO = await _daleClient.GetCustomer();

            if (CustomerDTO == null)
            {
                return NotFound();
            }
            return Page();
        }

        private readonly IDaleClientCustomer _daleClient;
    }
}