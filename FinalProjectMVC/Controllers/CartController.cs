using FinalProjectMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Models.Models;
using Services.Interfaces;
using Services.Repository;
using System.Text.Json;

namespace FinalProjectMVC.Controllers
{
    public class CartController : Controller
    {
        IProductService _productService;
        public CartController(IProductService productService) 
        { 
            _productService = productService;
        }
    }
}
