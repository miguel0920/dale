using Dale.WebSite.Apis;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Dale.WebSite.Pages.Customer
{
    public class EditModel : PageModel
    {
        public EditModel(IDaleClientCustomer daleClient) => _daleClient = daleClient;

        [BindProperty]
        public Models.CustomerDto CustomerDTO { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CustomerDTO = await _daleClient.GetCustomerById(id.Value);

            if (CustomerDTO == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _daleClient.UpdateCustomer(CustomerDTO);

            return RedirectToPage("./Index");
        }

        private readonly IDaleClientCustomer _daleClient;
    }
}