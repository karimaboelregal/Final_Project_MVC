using FinalProjectMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Models.Models;
using Services.Interfaces;
using System.Diagnostics;

namespace FinalProjectMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICategoryService categoryService;
        private readonly IProductService productService;

        public HomeController(ILogger<HomeController> logger, ICategoryService _categoryService, IProductService _productService)
        {
            _logger = logger;
            categoryService = _categoryService;
            productService = _productService;
        }

        public async Task<IActionResult> IndexAsync()
        {
            ProductViewModel model = new ProductViewModel();
            //model.categories = await categoryService.GetCategories();
            //model.products = await productService.GetProductList();
            model.login = new LoginModel(); ;
            model.registration = new RegistrationModel();

            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Category(string id)
        {
            ProductViewModel model = new ProductViewModel();
            //model.categories = await categoryService.GetCategories();
            //model.products = await productService.GetProductsFromCategory(id);
            model.login = new LoginModel(); ;
            model.registration = new RegistrationModel();
            return View("Index", model);
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public ActionResult ModalAction(int Id)
        {
            ViewBag.Id = Id;
            return PartialView("_LoginPartial");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}