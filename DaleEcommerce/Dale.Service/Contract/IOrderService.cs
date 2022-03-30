using Dale.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dale.Services.Contract
{
    internal interface IOrderService
    {
        Task<string> CreateOrder(CreateOrder order);
    }
}