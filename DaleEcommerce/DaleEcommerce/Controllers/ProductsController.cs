using Dale.Domain;
using Dale.Services.Contract;
using Microsoft.AspNetCore.Mvc;

namespace DaleEcommerce.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        public ProductsController(IProductsService productsService)
        {
            _productsService = productsService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> Get()
        {
            return Ok(await _productsService.GetProducts());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetById(int id)
        {
            return Ok(await _productsService.GetProductById(id));
        }

        [HttpPost]
        public async Task<ActionResult<string>> Post(Product product)
        {
            return Ok(await _productsService.CreateProduct(product));
        }

        [HttpPut]
        public async Task<ActionResult<string>> Put(Product product)
        {
            return Ok(await _productsService.UpdateProduct(product));
        }

        [HttpDelete]
        public async Task<ActionResult<string>> Delete(int id)
        {
            return Ok(await _productsService.RemoveProduct(id));
        }

        private readonly IProductsService _productsService;
    }
}