using Dale.Domain;

namespace Dale.Persistence.Database.Interfaces
{
    public interface IProductsInfrastructure
    {
        Task<List<Product>> SelectProducts();
        Task<Product> SelectProductById(int productId);
        Task<string> InsertProduct(Product product);
        Task<string> UpdateProduct(Product product);
        Task<string> DeleteProduct(int productId);
    }
}