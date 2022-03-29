using Dale.Domain;
using Dale.Persistence.Database.Entities;
using Dale.Persistence.Database.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Dale.Persistence.Database.Imple
{
    public class ProductsInfrastructure : IProductsInfrastructure
    {
        public ProductsInfrastructure(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<List<Product>> SelectProducts()
        {
            List<Product> products = new();
            var productsDb = await _applicationDbContext.ProductsEntity.ToListAsync();
            if (productsDb.Count > 0)
            {
                productsDb.ForEach(x =>
                {
                    products.Add(new Product
                    {
                        Id = x.ProductId,
                        Name = x.ProductName,
                        Stock = x.ProductStock,
                        Value = x.ProductValue
                    });
                });
            }
            return products;
        }

        public async Task<Product> SelectProductById(int productId)
        {
            Product product = new();
            var productsDb = await _applicationDbContext.ProductsEntity.FirstOrDefaultAsync(x => x.ProductId == productId);
            if (productsDb != null)
            {
                product.Id = productsDb.ProductId;
                product.Name = productsDb.ProductName;
                product.Stock = productsDb.ProductStock;
                product.Value = productsDb.ProductValue;
            }
            return product;
        }

        public async Task<string> InsertProduct(Product product)
        {
            ProductsEntity productsEntity = new()
            {
                ProductName = product.Name,
                ProductStock = product.Stock,
                ProductValue = product.Value
            };

            await _applicationDbContext.ProductsEntity.AddAsync(productsEntity);
            await _applicationDbContext.SaveChangesAsync();
            return "Producto creado correctamente";
        }

        public async Task<string> UpdateProduct(Product product)
        {
            string result = string.Empty;
            var productDb = await _applicationDbContext.ProductsEntity.FirstOrDefaultAsync(x => x.ProductId == product.Id);
            if (productDb != null)
            {
                productDb.ProductName = product.Name;
                productDb.ProductStock = product.Stock;
                productDb.ProductValue = product.Value;
                _applicationDbContext.ProductsEntity.Update(productDb);
                await _applicationDbContext.SaveChangesAsync();
                result = "Producto actualizado correctamente";
            }
            else
            {
                result = "Product no encontrado";
            }
            return result;
        }

        public async Task<string> DeleteProduct(int productId)
        {
            string result = string.Empty;
            var productDb = await _applicationDbContext.ProductsEntity.FirstOrDefaultAsync(x => x.ProductId == productId);
            if (productDb != null)
            {
                _applicationDbContext.ProductsEntity.Remove(productDb);
                await _applicationDbContext.SaveChangesAsync();
                result = "El producto se elimino correctamente";
            }
            else
            {
                result = "Product no encontrado";
            }
            return result;
        }

        private readonly ApplicationDbContext _applicationDbContext;
    }
}