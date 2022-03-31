using Dale.Domain;
using Dale.Persistence.Database.Entities;
using Dale.Persistence.Database.Interfaces;

namespace Dale.Persistence.Database.Imple
{
    public class OrderInfrastructure : IOrderInfrastructure
    {
        public OrderInfrastructure(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public Task<string> InsertOrder(CreateOrder order)
        {
            OrdersEntity ordersEntity = new()
            {
                CustomerId = order.ClientId,
                Reference = order.Reference,
                TotalQuantity = order.TotalQuantity,
                TotalValue = order.TotalValue,
            };
            _applicationDbContext.OrdersEntity.Add(ordersEntity);

            List<OrderDetailsEntity> orderDetailsEntity = new();
            order.Detail.ForEach(detail =>
            {
                orderDetailsEntity.Add(new OrderDetailsEntity
                {
                    OrderId = ordersEntity.OrderId,
                    ProductId = detail.ProductId,
                    Quantity = detail.Quantity,
                });
            });

            _applicationDbContext.OrderDetailEntity.AddRange(orderDetailsEntity);
            var result = _applicationDbContext.SaveChanges();
            return Task.FromResult(result <= 0 ? "No fue posible crear la orden" : $"Orden {order.Reference} creada correctamente");
        }

        public Task<List<Order>> ListOrder()
        {
            var orderDb = from order in _applicationDbContext.OrdersEntity
                          join customer in _applicationDbContext.CustomersEntity on order.CustomerId equals customer.CustomerId
                          select new Order
                          {
                              Id = order.OrderId,
                              FullName = customer.FirstName + " " + customer.LastName,
                              Document = customer.DocumentNumber,
                              Phone = customer.Phone,
                              Reference = order.Reference,
                              TotalValue = order.TotalValue,
                              Total = order.TotalQuantity
                          };

            return Task.FromResult(orderDb.ToList());
        }

        public Task<Order> SelectOrderById(int id)
        {
            Order orderResult = new();
            var orderDb = from order in _applicationDbContext.OrdersEntity
                          join customer in _applicationDbContext.CustomersEntity on order.CustomerId equals customer.CustomerId
                          where order.OrderId == id
                          select new Order
                          {
                              Id = order.OrderId,
                              FullName = customer.FirstName + " " + customer.LastName,
                              Document = customer.DocumentNumber,
                              Phone = customer.Phone,
                              Reference = order.Reference,
                              TotalValue = order.TotalValue,
                              Total = order.TotalQuantity
                          };

            var orderDetailDb = from order in _applicationDbContext.OrdersEntity
                                join orderDetail in _applicationDbContext.OrderDetailEntity on order.OrderId equals orderDetail.OrderId
                                join product in _applicationDbContext.ProductsEntity on orderDetail.ProductId equals product.ProductId
                                where order.OrderId == id
                                select new Detail
                                {
                                    OrderId = order.OrderId,
                                    ProductName = product.ProductName,
                                    Quantity = orderDetail.Quantity,
                                    Value = orderDetail.Value
                                };
            if (orderDb != null)
            {
                var listDetail = orderDetailDb.ToList().Where(x => x.OrderId == orderDb.FirstOrDefault().Id);
                orderResult.Id = orderDb.FirstOrDefault().Id;
                orderResult.FullName = orderDb.FirstOrDefault().FullName;
                orderResult.Document = orderDb.FirstOrDefault().Document;
                orderResult.Phone = orderDb.FirstOrDefault().Phone;
                orderResult.Reference = orderDb.FirstOrDefault().Reference;
                orderResult.TotalValue = orderDb.FirstOrDefault().TotalValue;
                orderResult.Total = orderDb.FirstOrDefault().Total;
                orderResult.Detail = listDetail.ToList();
            }

            return Task.FromResult(orderResult);
        }

        private readonly ApplicationDbContext _applicationDbContext;
    }
}