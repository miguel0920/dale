using Dale.Domain;
using Dale.Persistence.Database.Interfaces;
using Dale.Services.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dale.Services
{
    public class OrderService : IOrderService
    {
        public OrderService(IOrderInfrastructure orderInfrastructure)
        {
            _orderInfrastructure = orderInfrastructure;
        }

        public Task<string> CreateOrder(CreateOrder order)
        {
            try
            {
                var result = _orderInfrastructure.InsertOrder(order);
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