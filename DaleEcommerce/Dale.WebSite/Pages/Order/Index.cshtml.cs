using Dale.WebSite.Apis;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Dale.WebSite.Pages.Order
{
    public class IndexModel : PageModel
    {
        public IndexModel(IDaleClientOrder daleClient)
        {
            _daleClient = daleClient;
        }

        [BindProperty]
        public List<Models.Order>? OrderDTO { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            OrderDTO = await _daleClient.GetOrders();

            if (OrderDTO == null)
            {
                return NotFound();
            }
            return Page();
        }

        private readonly IDaleClientOrder _daleClient;
    }
}
