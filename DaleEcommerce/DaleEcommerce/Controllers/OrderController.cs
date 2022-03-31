using Dale.Domain;
using Dale.Services.Contract;
using Microsoft.AspNetCore.Mvc;

namespace DaleEcommerce.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<ActionResult<Order>> Get()
        {
            return Ok(await _orderService.GetOrders());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetById(int id)
        {
            return Ok(await _orderService.GetOrderById(id));
        }

        [HttpPost]
        public async Task<ActionResult<string>> Post(CreateOrder order)
        {
            return Ok(await _orderService.CreateOrder(order));
        }

        private readonly IOrderService _orderService;
    }
}