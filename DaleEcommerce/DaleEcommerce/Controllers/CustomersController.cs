using Dale.Domain;
using Dale.Services.Contract;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DaleEcommerce.Controllers
{
    [Route("api/customers")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Customer>>> Get()
        {
            return Ok(await _customerService.GetCustomer());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetById(int id)
        {
            return Ok(await _customerService.GetCustomerById(id));
        }

        [HttpPost]
        public async Task<ActionResult<string>> Post(Customer customer)
        {
            return Ok(await _customerService.CreateCustomer(customer));
        }

        [HttpPut]
        public async Task<ActionResult<string>> Put(Customer customer)
        {
            return Ok(await _customerService.UpdateCustomer(customer));
        }

        [HttpDelete]
        public async Task<ActionResult<string>> Delete(int id)
        {
            return Ok(await _customerService.RemoveCustomer(id));
        }

        private readonly ICustomerService _customerService;
    }
}