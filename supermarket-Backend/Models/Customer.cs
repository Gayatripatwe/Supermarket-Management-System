using System.ComponentModel.DataAnnotations;

namespace Supermarket_Managementsystem.Models
{
    public class Customer
    {
        [Key]
        public  int id { get; set; }

        public string name { get; set; } = String.Empty;
        [Required]
        public string phoneno { get; set; } = String.Empty;
        public string email { get; set; } = string.Empty;
        public List<Order> orders { get; set; } = new List<Order>();

    }
}
