namespace Dale.WebSite.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Document { get; set; }
        public string Phone { get; set; }
        public Guid Reference { get; set; }
        public decimal TotalValue { get; set; }
        public int Total { get; set; }
        public List<Detail> Detail { get; set; } = new List<Detail>();
    }

    public class Detail
    {
        public int OrderId { get; set; }
        public string ProductName { get; set; }
        public decimal Value { get; set; }
        public int Quantity { get; set; }
    }
}