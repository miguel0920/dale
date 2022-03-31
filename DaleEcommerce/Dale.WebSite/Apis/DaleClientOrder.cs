using Dale.WebSite.Models;
using Microsoft.Extensions.Options;
using System.Text.Json;

namespace Dale.WebSite.Apis
{
    public interface IDaleClientOrder
    {
        Task<List<Order>?> GetOrders();
        Task<Order?> GetOrderById(int id);
    }
    public class DaleClientOrder : IDaleClientOrder
    {
        public DaleClientOrder(HttpClient httpClient, IOptions<ApiUrls> apiUrls)
        {
            _httpClient = httpClient;
            _apiUrls = apiUrls.Value;
        }

        public async Task<List<Order>?> GetOrders()
        {
            var request = await _httpClient.GetAsync($"{_apiUrls.UrlDale}/api/orders");
            request.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<List<Order>>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
        }

        public async Task<Order?> GetOrderById(int id)
        {
            var request = await _httpClient.GetAsync($"{_apiUrls.UrlDale}/api/orders/{id}");
            request.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<Order>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
        }



        private HttpClient _httpClient;
        private readonly ApiUrls _apiUrls;
    }
}