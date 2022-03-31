using Dale.WebSite.Apis;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Dale.WebSite.Pages.Customer
{
    public class DeleteModel : PageModel
    {
        public DeleteModel(IDaleClientCustomer daleClient) => _daleClient = daleClient;

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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }

                var result = await _daleClient.DeleteCustomer(id.Value);

                return RedirectToPage("./Index");
            }
            catch (Exception)
            {
                ViewData["Message"] = "No fue posible eliminar el cliente porque puede estar relacionado a una compra o no fue encontrado";
                return null;
            }
        }

        private readonly IDaleClientCustomer _daleClient;
    }
}