using System.ComponentModel.DataAnnotations;

namespace Supermarket_Managementsystem.Models
{
    public class Category
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; } = String.Empty;
        public string discription { get; set; } = String.Empty;

        public List<Product> products { get; set; } = new List<Product>();
    }
}
