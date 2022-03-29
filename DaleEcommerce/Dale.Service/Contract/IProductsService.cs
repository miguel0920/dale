using Dale.Domain;

namespace Dale.Services.Contract
{
    public interface IProductsService
    {
        Task<string> CreateProduct(Product product);
        Task<Product> GetProductById(int id);
        Task<List<Product>> GetProducts();
        Task<string> RemoveProduct(int id);
        Task<string> UpdateProduct(Product product);
    }
}