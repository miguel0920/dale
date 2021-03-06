using Dale.WebSite.Apis;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Dale.WebSite.Pages.Product
{
    public class DeleteModel : PageModel
    {
        public DeleteModel(IDaleClientProduct daleClient) => _daleClient = daleClient;

        [BindProperty]
        public Models.ProductDto ProductDTO { get; set; }

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
            try
            {
                if (id == null)
                {
                    return NotFound();
                }

                var result = await _daleClient.DeleteProduct(id.Value);

                return RedirectToPage("./Index");
            }
            catch
            {
                ViewData["Message"] = "No fue posible eliminar el producto porque puede estar relacionado a una compra o no fue encontrado";
                return null;
            }
        }

        private readonly IDaleClientProduct _daleClient;
    }
}