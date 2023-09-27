using E_Commerce.Data.Context;
using Models.Models;
using E_Commerce.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Models;
using Models.Models;
using Services.Interfaces;
using E_Commerce.Repository.Unit;

namespace Services.Repository
{
    public class AdminService : IAdminService
    {
        private readonly UnitOfWork unitOfWork;
        public AdminService(UnitOfWork _unitOFWork)
        {
            unitOfWork = _unitOFWork;
        }
    }
}
