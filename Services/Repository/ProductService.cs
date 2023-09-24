using E_Commerce.Data.Context;
using Models.Models;
using E_Commerce.Repository.Unit;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Services.Interfaces;

namespace Services.Repository
{
    public class ProductService : IProductService
    {
        private readonly UnitOfWork unitOfWork;
        public ProductService(UnitOfWork _unitOFWork)
        {
            unitOfWork = _unitOFWork;
        }
        public async Task<List<Product>> GetProductList()
        {
            List<Product> prods = (List<Product>)await unitOfWork.productRepository.GetAll();
            return prods;
        }
    }
}
