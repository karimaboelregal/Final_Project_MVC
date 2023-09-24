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

        public HomeController(ILogger<HomeController> logger, ICategoryService _categoryService)
        {
            _logger = logger;
            categoryService = _categoryService;
        }

        public async Task<IActionResult> IndexAsync()
        {
            LayoutViewModel model = new LayoutViewModel();
            model.categories = await categoryService.GetCategories();


            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}