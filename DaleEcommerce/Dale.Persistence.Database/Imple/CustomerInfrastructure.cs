using Dale.Domain;
using Dale.Persistence.Database.Entities;
using Dale.Persistence.Database.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Dale.Persistence.Database.Imple
{
    public class CustomerInfrastructure : ICustomerInfrastructure
    {
        public CustomerInfrastructure(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<List<Customer>> SelectCustomer()
        {
            List<Customer> customers = new();
            var customersDb = await _applicationDbContext.CustomersEntity.ToListAsync();
            if (customersDb.Count > 0)
            {
                customersDb.ForEach(x =>
                {
                    customers.Add(new Customer
                    {
                        Id = x.CustomerId,
                        FirstName = x.FirstName,
                        LastName = x.LastName,
                        DocumentNumber = x.DocumentNumber,
                        CellPhone = x.Phone
                    });
                });
            }
            return customers;
        }

        public async Task<Customer> SelectCustomerById(int customerId)
        {
            Customer customer = new();
            var customerDb = await _applicationDbContext.CustomersEntity.FirstOrDefaultAsync(x => x.CustomerId == customerId);
            if (customerDb != null)
            {
                customer.Id = customerDb.CustomerId;
                customer.FirstName = customerDb.FirstName;
                customer.LastName = customerDb.LastName;
                customer.DocumentNumber = customerDb.DocumentNumber;
            }
            return customer;
        }

        public async Task<string> InsertCustomer(Customer customer)
        {
            CustomersEntity customerEntity = new()
            {
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                DocumentNumber = customer.DocumentNumber,
                Phone = customer.CellPhone
            };

            await _applicationDbContext.CustomersEntity.AddAsync(customerEntity);
            await _applicationDbContext.SaveChangesAsync();
            return "Cliente creado correctamente";
        }

        public async Task<string> UpdateCustomer(Customer customer)
        {
            string result = string.Empty;
            var customerDb = await _applicationDbContext.CustomersEntity.FirstOrDefaultAsync(x => x.CustomerId == customer.Id);
            if (customerDb != null)
            {
                customerDb.FirstName = customer.FirstName;
                customerDb.LastName = customer.LastName;
                customerDb.DocumentNumber = customer.DocumentNumber;
                customerDb.Phone = customer.CellPhone;
                _applicationDbContext.CustomersEntity.Update(customerDb);
                await _applicationDbContext.SaveChangesAsync();
                result = "Cliente actualizado correctamente";
            }
            else
            {
                result = "Cliente no encontrado";
            }
            return result;
        }

        public async Task<string> DeleteCustomer(int customerId)
        {
            string result = string.Empty;
            var customerDb = await _applicationDbContext.CustomersEntity.FirstOrDefaultAsync(x => x.CustomerId == customerId);
            if (customerDb != null)
            {
                _applicationDbContext.CustomersEntity.Remove(customerDb);
                await _applicationDbContext.SaveChangesAsync();
                result = "El cliente se elimino correctamente";
            }
            else
            {
                result = "cliente no encontrado";
            }
            return result;
        }

        private readonly ApplicationDbContext _applicationDbContext;
    }
}