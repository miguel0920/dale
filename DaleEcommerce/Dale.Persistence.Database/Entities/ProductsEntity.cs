using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dale.Persistence.Database.Entities
{
    [Table("Products")]
    public class ProductsEntity
    {
        [Key]
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal ProductValue { get; set; }
        public int ProductStock { get; set; }
    }
}