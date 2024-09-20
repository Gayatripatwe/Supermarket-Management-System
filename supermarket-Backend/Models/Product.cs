using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Supermarket_Managementsystem.Models
{
    public class Product
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; } = String.Empty;

        public int quantity { get; set; } = 0;
        public double price { get; set; }
        [ForeignKey("categoryid")]
        public int categoryid { get; set; }
        public Category category { get; set; } = new Category();

    }
}
