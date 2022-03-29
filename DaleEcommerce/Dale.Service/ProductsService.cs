using Dale.Domain;
using Dale.Persistence.Database.Interfaces;
using Dale.Services.Contract;

namespace Dale.Service
{
    public class ProductsService : IProductsService
    {
        public ProductsService(IProductsInfrastructure productsInfrastructure)
        {
            _productsInfrastructure = productsInfrastructure;
        }

        public Task<List<Product>> GetProducts()
        {
            try
            {
                var result = _productsInfrastructure.SelectProducts();
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Task<Product> GetProductById(int id)
        {
            try
            {
                var result = _productsInfrastructure.SelectProductById(id);
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Task<string> CreateProduct(Product product)
        {
            try
            {
                var result = _productsInfrastructure.InsertProduct(product);
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Task<string> UpdateProduct(Product product)
        {
            try
            {
                var result = _productsInfrastructure.UpdateProduct(product);
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Task<string> RemoveProduct(int id)
        {
            try
            {
                var result = _productsInfrastructure.DeleteProduct(id);
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private readonly IProductsInfrastructure _productsInfrastructure;
    }
}