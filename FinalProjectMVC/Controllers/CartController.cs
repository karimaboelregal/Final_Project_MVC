using FinalProjectMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Models.Models;
using Newtonsoft.Json;
using Services.Interfaces;
using Services.Repository;
using System.Text.Json;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace FinalProjectMVC.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IOrderService _orderService;
        private readonly IOrderDetailsService _detailsService;
        private readonly UserManager<Customer> _userManager;

        public CartController(IProductService productService, ICategoryService categoryService, IOrderService orderService, UserManager<Customer> userManager, IOrderDetailsService detailsService)
        {
            _productService = productService;
            _categoryService = categoryService;
            _orderService = orderService;
            _userManager = userManager;
            _detailsService = detailsService;
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
            }
            else
            {
                item.ProductCount--;
            }
            HttpContext.Session.SetString("cart", System.Text.Json.JsonSerializer.Serialize(cart));
        }
        [HttpPost]
        public async Task<IActionResult> Checkout()
        {
            Cart cart = await GetCartFromSession();
            var claims = User.Claims;
            string id = claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
            Order order = await _orderService.AddOrderAsync(Guid.Parse(id), cart.TotalPrice);

            foreach (Item item in cart.Items)
            {
                await _detailsService.AddDetails(order, item.Product, item.ProductCount);
            }
            return Redirect("https://localhost:7128");
        }
    }
}
