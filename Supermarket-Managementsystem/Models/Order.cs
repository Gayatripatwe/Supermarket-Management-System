using System.ComponentModel.DataAnnotations;

namespace Supermarket_Managementsystem.Models
{
    public class Order
    {
        [Key]
        public int id { get; set; }
        public double totalprice { get; set; }
        public string date { get; set; }
        public int Customerid { get; set; }
        public Customer ?customer { get; set; }
         public ICollection<Orderitem> ?orderitems { get; set; }


    }
}
