using Dale.Domain;

namespace Dale.Persistence.Database.Interfaces
{
    public interface ICustomerInfrastructure
    {
        Task<List<Customer>> SelectCustomer();
        Task<Customer> SelectCustomerById(int customerId);
        Task<string> InsertCustomer(Customer customer);
        Task<string> UpdateCustomer(Customer customer);
        Task<string> DeleteCustomer(int customerId);
    }
}