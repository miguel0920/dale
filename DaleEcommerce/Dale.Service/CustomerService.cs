using Dale.Domain;
using Dale.Persistence.Database.Interfaces;
using Dale.Services.Contract;

namespace Dale.Services
{
    public class CustomerService : ICustomerService
    {
        public CustomerService(ICustomerInfrastructure customerInfrastructure)
        {
            _customerInfrastructure = customerInfrastructure;
        }

        public Task<List<Customer>> GetCustomer()
        {
            try
            {
                var result = _customerInfrastructure.SelectCustomer();
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Task<Customer> GetCustomerById(int id)
        {
            try
            {
                var result = _customerInfrastructure.SelectCustomerById(id);
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Task<string> CreateCustomer(Customer customer)
        {
            try
            {
                var result = _customerInfrastructure.InsertCustomer(customer);
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Task<string> UpdateCustomer(Customer customer)
        {
            try
            {
                var result = _customerInfrastructure.UpdateCustomer(customer);
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Task<string> RemoveCustomer(int id)
        {
            try
            {
                var result = _customerInfrastructure.DeleteCustomer(id);
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private readonly ICustomerInfrastructure _customerInfrastructure;
    }
}