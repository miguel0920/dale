using Dale.WebSite.Apis;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Dale.WebSite.Pages.Product
{
    public class CreateModel : PageModel
    {
        public CreateModel(IDaleClientProduct daleClient) => _daleClient = daleClient;

        [BindProperty]
        public Models.ProductDto ProductDTO { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _daleClient.CreateProduct(ProductDTO);

            return RedirectToPage("./Index");
        }

        private readonly IDaleClientProduct _daleClient;
    }
}