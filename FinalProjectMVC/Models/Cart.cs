using Models.Models;

namespace FinalProjectMVC.Models
{
    public class Cart
    {
        public List<Item> Items { get; set; } = new List<Item>();
        public decimal TotalPrice { get => Items.Sum(item => item.Product.UnitPrice * item.ProductCount); }
    }
}
