using Dale.Domain;
using Dale.Persistence.Database.Interfaces;
using Dale.Services.Contract;

namespace Dale.Services
{
    public class OrderService : IOrderService
    {
        public OrderService(IOrderInfrastructure orderInfrastructure)
        {
            _orderInfrastructure = orderInfrastructure;
        }

        public async Task<string> CreateOrder(CreateOrder order)
        {
            try
            {
                var result = await _orderInfrastructure.InsertOrder(order);
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<Order>> GetOrders()
        {
            try
            {
                var result = await _orderInfrastructure.ListOrder();
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Order> GetOrderById(int id)
        {
            try
            {
                var result = await _orderInfrastructure.SelectOrderById(id);
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private readonly IOrderInfrastructure _orderInfrastructure;
    }
}