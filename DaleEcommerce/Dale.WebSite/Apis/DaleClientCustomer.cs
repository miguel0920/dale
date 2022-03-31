using Dale.WebSite.Models;
using Microsoft.Extensions.Options;
using System.Text;
using System.Text.Json;

namespace Dale.WebSite.Apis
{
    public interface IDaleClientCustomer
    {
        Task<string> CreateCustomer(CustomerDto customer);
        Task<string> DeleteCustomer(int id);
        Task<List<CustomerDto>?> GetCustomer();
        Task<CustomerDto?> GetCustomerById(int id);
        Task<string> UpdateCustomer(CustomerDto customer);
    }
    public class DaleClientCustomer : IDaleClientCustomer
    {
        public DaleClientCustomer(HttpClient httpClient, IOptions<ApiUrls> apiUrls)
        {
            _httpClient = httpClient;
            _apiUrls = apiUrls.Value;
        }

        public async Task<CustomerDto?> GetCustomerById(int id)
        {
            var request = await _httpClient.GetAsync($"{_apiUrls.UrlDale}/api/customers/{id}");
            request.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<CustomerDto>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
        }

        public async Task<List<CustomerDto>?> GetCustomer()
        {
            var request = await _httpClient.GetAsync($"{_apiUrls.UrlDale}/api/customers");
            request.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<List<CustomerDto>>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
        }

        public async Task<string> CreateCustomer(CustomerDto customer)
        {
            var content = new StringContent(
                JsonSerializer.Serialize(customer),
                Encoding.UTF8,
                "application/json"
            );

            var request = await _httpClient.PostAsync($"{_apiUrls.UrlDale}/api/customers", content);
            request.EnsureSuccessStatusCode();

            return await request.Content.ReadAsStringAsync();
        }

        public async Task<string> UpdateCustomer(CustomerDto customer)
        {
            var content = new StringContent(
                JsonSerializer.Serialize(customer),
                Encoding.UTF8,
                "application/json"
            );

            var request = await _httpClient.PutAsync($"{_apiUrls.UrlDale}/api/customers", content);
            request.EnsureSuccessStatusCode();

            return await request.Content.ReadAsStringAsync();
        }

        public async Task<string> DeleteCustomer(int id)
        {
            var request = await _httpClient.DeleteAsync($"{_apiUrls.UrlDale}/api/customers?id={id}");
            request.EnsureSuccessStatusCode();

            return await request.Content.ReadAsStringAsync();
        }

        private HttpClient _httpClient;
        private readonly ApiUrls _apiUrls;
    }
}