using Dale.Domain;

namespace Dale.Persistence.Database.Interfaces
{
    public interface IOrderInfrastructure
    {
        Task<List<Order>> ListOrder();
        Task<Order> SelectOrderById(int id);
        Task<string> InsertOrder(CreateOrder order);
    }
}