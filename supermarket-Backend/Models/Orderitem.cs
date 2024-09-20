using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Supermarket_Managementsystem.Models
{
    public class Orderitem
    {
        [Key]
        public int id { get; set; }
        public double price { get; set; }
        public int Quantity { get; set; }
        [ForeignKey("orderid")]
        public int orderid { get; set; }
        public Order order { get; set;}
        [ForeignKey("productid")]
        public int productid { get; set; }
        public Product product { get; set; }


    }
}
