using E_Commerce.Data.Context;
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
using E_Commerce.Repository.Unit;

namespace Services.Repository
{
    public class OrderService : IOrderService
    {
        private readonly UnitOfWork unitOfWork;
        public OrderService(UnitOfWork _unitOFWork)
        {
            unitOfWork = _unitOFWork;
        }

        public async Task<List<Order>> GetAllOrders(string id)
        {

            List<Order> orders = (List<Order>)await unitOfWork.orderRepository.GetAll(p => p.Customer.Id == Guid.Parse(id));
            return orders;
        }
        public async Task<Order> AddOrderAsync(Guid id, decimal totalprice)
        {
            Customer customer = await unitOfWork.customerRepository.Get(s => s.Id == id);
            Order order = new Order() { Customer = customer, IsDeleted = false, Status = Models.Models.Enum.Status.Pending, TotalPrice = totalprice };
            Order ord = await unitOfWork.orderRepository.Add(order);
            await unitOfWork.SaveChangesAsync();
            return ord;
        }

   
    }
}
