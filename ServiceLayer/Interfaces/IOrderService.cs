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
    public interface IOrderService
    {
        public Task<Order> AddOrderAsync(Guid id, decimal totalprice);
    }
}
