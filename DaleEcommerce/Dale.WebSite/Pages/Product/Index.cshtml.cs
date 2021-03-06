using Dale.WebSite.Apis;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Dale.WebSite.Pages.Product
{
    public class IndexModel : PageModel
    {
        public IndexModel(IDaleClientProduct daleClient) => _daleClient = daleClient;

        [BindProperty]
        public List<Models.ProductDto>? ProductDTO { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            ProductDTO = await _daleClient.GetProduct();

            if (ProductDTO == null)
            {
                return NotFound();
            }
            return Page();
        }

        private readonly IDaleClientProduct _daleClient;
    }
}