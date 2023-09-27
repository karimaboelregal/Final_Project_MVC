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
    public interface IOrderDetailsService
    {
        public Task<OrderDetails> AddDetails(Order order, Product product, int count);
    }
}
