﻿using Models.Models;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IProductService
    {
        Task<List<Product>> GetProductList();
        Task<List<Product>> GetProductsFromCategory(string id);
        Task<Product> GetProduct(string id);
    }
}
