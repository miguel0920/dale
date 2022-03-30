using Dale.WebSite.Apis;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Dale.WebSite.Pages.Product
{
    public class DeleteModel : PageModel
    {
        public DeleteModel(DaleClientProduct daleClient) => _daleClient = daleClient;

        [BindProperty]
        public Models.Product ProductDTO { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ProductDTO = await _daleClient.GetProductById(id.Value);

            if (ProductDTO == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var result = await _daleClient.DeleteProduct(id.Value);

            return RedirectToPage("./Index");
        }

        private readonly DaleClientProduct _daleClient;
    }
}