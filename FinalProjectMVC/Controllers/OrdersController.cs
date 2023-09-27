using FinalProjectMVC.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Models.Models;
using Services.Interfaces;
using System.Security.Claims;

namespace FinalProjectMVC.Controllers
{
    public class OrdersController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICategoryService categoryService;
        private readonly IProductService productService;
        private readonly IOrderService orderService;
     
        public OrdersController(ILogger<HomeController> logger, ICategoryService _categoryService, IProductService _productService, IOrderService _orderService)
        {
            _logger = logger;
            categoryService = _categoryService;
            productService = _productService;
            orderService = _orderService;
          

        }
        public async Task<IActionResult> IndexAsync()
        {
            ProductViewModel model = new ProductViewModel();
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            model.orders = await orderService.GetAllOrders(userId);
            model.categories = await categoryService.GetCategories();
            model.products = await productService.GetProductList();
            model.login = new LoginModel(); ;
            model.registration = new RegistrationModel();

            return View(model);
        }
    }
}
