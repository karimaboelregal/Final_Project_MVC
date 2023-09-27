using E_Commerce.Data.Context;
using Models.Models;
using E_Commerce.Repository.Interface;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Services.Interfaces;
using E_Commerce.Repository.Unit;

namespace Services.Repository
{
    public class OrderDetailsService : IOrderDetailsService
    {
        private readonly UnitOfWork unitOfWork;
        public OrderDetailsService(UnitOfWork _unitOFWork)
        {
            unitOfWork = _unitOFWork;
        }

        public async Task<OrderDetails> AddDetails(Order order, Product product, int count)
        {
            unitOfWork.productRepository.Attach(product);
            OrderDetails details = new OrderDetails() { Order = order, OrderId = order.Id, Product = product, ProductId = product.Id, ProductCount = count, UnitPrice = product.UnitPrice };
            OrderDetails ord = await unitOfWork.orderDetailsRepository.Add(details);
            await unitOfWork.SaveChangesAsync();
            return ord;
        }

    }
}
