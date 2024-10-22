using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OrderService.Models;

namespace OrderService.Data
{
    public class OrderDbContext:DbContext
    {
        public OrderDbContext(DbContextOptions<OrderDbContext> options ):base(options)
        {

        }
        public DbSet<OrderModel>Orders { get;set; }
        public DbSet<OrderItemModel>OrderItems { get;set;}
        
    }
}