using Dale.Domain;

namespace Dale.Services.Contract
{
    public interface IOrderService
    {
        Task<List<Order>> GetOrders();
        Task<Order> GetOrderById(int id);
        Task<string> CreateOrder(CreateOrder order);
    }
}