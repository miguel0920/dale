using Dale.WebSite.Apis;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Dale.WebSite.Pages.Order
{
    public class DetailModel : PageModel
    {
        public DetailModel(IDaleClientOrder daleClient)
        {
            _daleClient = daleClient;
        }

        [BindProperty]
        public Models.Order? OrderDTO { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            OrderDTO = await _daleClient.GetOrderById(id);

            if (OrderDTO == null)
            {
                return NotFound();
            }
            return Page();
        }

        private readonly IDaleClientOrder _daleClient;
    }
}