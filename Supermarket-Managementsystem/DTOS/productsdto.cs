namespace Supermarket_Managementsystem.DTOS
{
    public class productsdto
    {
        public string name { get; set; } = String.Empty;
        public int quantity { get; set; } = 0;
        public double price { get; set; }

        public int categoryid { get; set; }
    }
}
