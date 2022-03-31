namespace Dale.Domain
{
    public class CreateOrder
    {
        public int ClientId { get; set; }
        public decimal TotalValue { get; set; }
        public Guid Reference { get; set; }
        public int TotalQuantity { get; set; }
        public List<OrderDetail> Detail { get; set; }
    }

    public class OrderDetail
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}