using E_Commerce.Data.Context;
using Models.Models;
using E_Commerce.Repository.Interface;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services.Interfaces;
using E_Commerce.Repository.Unit;

namespace Services.Repository
{
    public class CategoryService : ICategoryService
    {
        private readonly UnitOfWork unitOfWork;
        public CategoryService(UnitOfWork _unitOFWork)
        {
            unitOfWork = _unitOFWork;
        }
        public async Task<List<Category>> GetCategories()
        {
            List<Category> categories = (List<Category>)await unitOfWork.categoryRepository.GetAll();
            return categories;
        }
    }
}
