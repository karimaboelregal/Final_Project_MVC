﻿using E_Commerce.Data.Context;
using Models.Models;
using E_Commerce.Repository.Interface;
using Models.Models;
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
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork unitOfWork;
        public OrderService(IUnitOfWork _unitOFWork)
        {
            unitOfWork = _unitOFWork;
        }


    }
}
