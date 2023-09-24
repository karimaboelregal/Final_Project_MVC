using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using E_Commerce.Data.Context;
using Models.Models;
using E_Commerce.Repository.Unit;
using Services.Interfaces;

namespace FinalProjectMVC.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService IProductService;

        public ProductsController(IProductService _IProductService)
        {
            IProductService = _IProductService;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            List<Product> Prods = await IProductService.GetProductList();
              return Prods != null ? 
                          View(Prods.ToList()) :
                          Problem("Entity set 'DataContext.Products'  is null.");
        }

    }
}
