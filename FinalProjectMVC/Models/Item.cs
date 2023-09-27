using Models.Models;

namespace FinalProjectMVC.Models
{
    public class Item
    {
        public Product Product { get; set; }
        public int ProductCount { get; set; }
        public Item()
        {

        }
        public Item(Product prod, int count)
        {
            Product = prod;
            ProductCount = count;
        }
    }
}
