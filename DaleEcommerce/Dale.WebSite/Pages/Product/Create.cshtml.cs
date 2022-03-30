using Dale.WebSite.Apis;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Dale.WebSite.Pages.Product
{
    public class CreateModel : PageModel
    {
        public CreateModel(DaleClientProduct daleClient) => _daleClient = daleClient;

        [BindProperty]
        public Models.Product ProductDTO { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _daleClient.CreateProduct(ProductDTO);

            return RedirectToPage("./Index");
        }

        private readonly DaleClientProduct _daleClient;
    }
}