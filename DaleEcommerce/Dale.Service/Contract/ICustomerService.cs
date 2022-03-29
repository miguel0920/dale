using Dale.Domain;

namespace Dale.Services.Contract
{
    public interface ICustomerService
    {
        Task<Customer> GetCustomerById(int id);
        Task<List<Customer>> GetCustomer();
        Task<string> CreateCustomer(Customer customer);
        Task<string> UpdateCustomer(Customer customer);
        Task<string> RemoveCustomer(int id);
    }
}