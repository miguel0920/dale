using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dale.Domain
{
    public class CreateOrder
    {
        public int ClientId { get; set; }
        public decimal TotalValue { get; set; }
        public string Reference { get; set; }
        public int TotalQuantity { get; set; }
        public List<OrderDetail> Detail { get; set; }
    }

    public class OrderDetail
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}