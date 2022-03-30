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

            _applicationDbContext.OrderDetail.AddRange(orderDetailsEntity);
            var result = _applicationDbContext.SaveChanges();
            return Task.FromResult(result <= 0 ? "No fue posible crear la orden" : $"Orden {order.Reference} creada correctamente");
        }

        private readonly ApplicationDbContext _applicationDbContext;
    }
}