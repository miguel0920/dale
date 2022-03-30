using Dale.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dale.Persistence.Database.Interfaces
{
    public interface IOrderInfrastructure
    {
        Task<string> InsertOrder(CreateOrder order);
    }
}