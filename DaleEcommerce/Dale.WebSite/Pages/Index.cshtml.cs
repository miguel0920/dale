using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Dale.WebSite.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            //using (var httpClient = new HttpClient())
            //{
            //    var contactsClient = new ContactsClient(httpClient);
            //    var contacts = await contactsClient.GetContactsAsync();
            //}
        }
    }
}