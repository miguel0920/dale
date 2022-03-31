using Dale.WebSite.Models;
using Microsoft.Extensions.Options;
using System.Text;
using System.Text.Json;

namespace Dale.WebSite.Apis
{
    public interface IDaleClientProduct
    {
        Task<string> CreateProduct(ProductDto product);
        Task<string> DeleteProduct(int id);
        Task<List<ProductDto>?> GetProduct();
        Task<ProductDto?> GetProductById(int id);
        Task<string> UpdateProduct(ProductDto product);
    }
    public class DaleClientProduct : IDaleClientProduct
    {
        public DaleClientProduct(HttpClient httpClient, IOptions<ApiUrls> apiUrls)
        {
            _httpClient = httpClient;
            _apiUrls = apiUrls.Value;
        }

        public async Task<ProductDto?> GetProductById(int id)
        {
            var request = await _httpClient.GetAsync($"{_apiUrls.UrlDale}/api/products/{id}");
            request.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<ProductDto>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
        }

        public async Task<List<ProductDto>?> GetProduct()
        {
            var request = await _httpClient.GetAsync($"{_apiUrls.UrlDale}/api/products");
            request.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<List<ProductDto>>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
        }

        public async Task<string> CreateProduct(ProductDto product)
        {
            var content = new StringContent(
                JsonSerializer.Serialize(product),
                Encoding.UTF8,
                "application/json"
            );

            var request = await _httpClient.PostAsync($"{_apiUrls.UrlDale}/api/products", content);
            request.EnsureSuccessStatusCode();

            return await request.Content.ReadAsStringAsync();
        }

        public async Task<string> UpdateProduct(ProductDto product)
        {
            var content = new StringContent(
                JsonSerializer.Serialize(product),
                Encoding.UTF8,
                "application/json"
            );

            var request = await _httpClient.PutAsync($"{_apiUrls.UrlDale}/api/products", content);
            request.EnsureSuccessStatusCode();

            return await request.Content.ReadAsStringAsync();
        }

        public async Task<string> DeleteProduct(int id)
        {
            var request = await _httpClient.DeleteAsync($"{_apiUrls.UrlDale}/api/products?id={id}");
            request.EnsureSuccessStatusCode();

            return await request.Content.ReadAsStringAsync();
        }

        private HttpClient _httpClient;
        private readonly ApiUrls _apiUrls;
    }
}