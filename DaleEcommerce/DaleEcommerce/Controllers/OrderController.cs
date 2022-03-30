using Dale.Domain;
using Dale.Services;
using Microsoft.AspNetCore.Mvc;

namespace DaleEcommerce.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        public OrderController(OrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        public async Task<ActionResult<string>> Post(CreateOrder order)
        {
            return Ok(await _orderService.CreateOrder(order));
        }

        private readonly OrderService _orderService;
    }
}