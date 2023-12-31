﻿using FinalProjectMVC.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Models.Models;
using Services.Interfaces;
using Services.Repository;
using System.Diagnostics;
using System.Text.Json;

namespace FinalProjectMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICategoryService categoryService;
        private readonly IProductService productService;
        private readonly UserManager<Customer> _userManager;
        private readonly SignInManager<Customer> _signInManager;


        public HomeController(ILogger<HomeController> logger, ICategoryService _categoryService, IProductService _productService, UserManager<Customer> userManager, SignInManager<Customer> signInManager)
        {
            _logger = logger;
            categoryService = _categoryService;
            productService = _productService;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IActionResult> IndexAsync()
        {
            ProductViewModel model = new ProductViewModel();
            model.Cart = await GetCartFromSession();
            model.categories = await categoryService.GetCategories();
            model.products = await productService.GetProductList();
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
                return JsonSerializer.Deserialize<Cart>(sessionString)!;
            }



            return new Cart();
        }
        [HttpPost]
        public async Task<IActionResult> AddToCart()
        {
            string i = HttpContext.Request.Form["id"];
            Cart cart = await GetCartFromSession();



            var product = await productService.GetProduct(i);

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
                HttpContext.Session.SetString("cart", JsonSerializer.Serialize(cart));



                TempData["Success"] = "The product is added successfully";



                return Redirect("https://localhost:7128");
            }



            return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> Category(string id)
        {
            ProductViewModel model = new ProductViewModel();
            model.categories = await categoryService.GetCategories();
            model.products = await productService.GetProductsFromCategory(id);
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