using Dale.WebSite.Apis;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Dale.WebSite.Pages.Product
{
    public class IndexModel : PageModel
    {
        public IndexModel(DaleClientProduct daleClient) => _daleClient = daleClient;

        [BindProperty]
        public List<Models.Product>? ProductDTO { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            ProductDTO = await _daleClient.GetProduct();

            if (ProductDTO == null)
            {
                return NotFound();
            }
            return Page();
        }

        private readonly DaleClientProduct _daleClient;
    }
}
