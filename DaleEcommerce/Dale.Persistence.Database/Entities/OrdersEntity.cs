using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dale.Persistence.Database.Entities
{
    [Table("Orders")]
    public class OrdersEntity
    {
        [Key]
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public string Reference { get; set; }
        public decimal TotalValue { get; set; }
        public int TotalQuantity { get; set; }
    }
}