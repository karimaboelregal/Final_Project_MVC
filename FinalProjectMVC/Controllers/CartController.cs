using FinalProjectMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Models.Models;
using Newtonsoft.Json;
using Services.Interfaces;
using Services.Repository;
using System.Text.Json;

namespace FinalProjectMVC.Controllers
{
    public class CartController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public CartController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        public async Task<IActionResult> IndexAsync()
        {
            ProductViewModel model = new ProductViewModel();
            model.Cart = await GetCartFromSession();
            model.categories = await _categoryService.GetCategories();
            model.login = new LoginModel(); ;
            model.registration = new RegistrationModel();

            return View(model);
        }

        private async Task<Cart> GetCartFromSession()
        {
            await HttpContext.Session.LoadAsync();
            var sessionString = HttpContext.Session.GetString("cart");
            if (sessionString is not null)
            {
                return System.Text.Json.JsonSerializer.Deserialize<Cart>(sessionString)!;
            }



            return new Cart();
        }
        [HttpPost]
        public async Task<IActionResult> AddToCart()
        {
            string i = HttpContext.Request.Form["id"];
            Cart cart = await GetCartFromSession();



            var product = await _productService.GetProduct(i);

            Guid id = Guid.Parse(i);


            if (product is not null)
            {



                if (cart.Items.Exists(item => item.Product.Id == id))
                {
                    cart.Items.Find(item => item.Product.Id == id)!.ProductCount++;
                }
                else
                {
                    cart.Items.Add(new Item(product, 1));
                }
                HttpContext.Session.SetString("cart", System.Text.Json.JsonSerializer.Serialize(cart));



                TempData["Success"] = "The product is added successfully";



                return Redirect("https://localhost:7128");
            }

            return NotFound();
        }
        [HttpPost]
        public async void IncrementItem(string i)
        {
            Cart cart = await GetCartFromSession();
            Guid id = Guid.Parse(i);
            cart.Items.Find(item => item.Product.Id == id).ProductCount++;
            HttpContext.Session.SetString("cart", System.Text.Json.JsonSerializer.Serialize(cart));
        }
        [HttpPost]
        public async void DecrementItem(string i)
        {
            Cart cart = await GetCartFromSession();
            Guid id = Guid.Parse(i);
            Item item = cart.Items.Find(item => item.Product.Id == id);
            if (item.ProductCount == 1)
            {
                cart.Items.Remove(item);
            } else
            {
                item.ProductCount--;
            }
            HttpContext.Session.SetString("cart", System.Text.Json.JsonSerializer.Serialize(cart));
        }
    }
}
