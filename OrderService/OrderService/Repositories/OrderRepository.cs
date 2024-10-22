using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OrderService.Data;
using OrderService.Models;

namespace OrderService.Repositories
{
    public class OrderRepository:IOrderRepository
    {
        private readonly OrderDbContext _context;
        public OrderRepository(OrderDbContext context)
        {
            _context= context;
        }
        public async Task<OrderModel>GetOrderByIdAsync(int orderId)
        {
            return await _context.Orders.Include(o=>o.OrderItems).FirstOrDefaultAsync(o=>o.OrderId == orderId);

        }
        public async Task<IEnumerable<OrderModel>> GetAllOrdersAsync()
        {
            return await _context.Orders
            .Include(o => o.OrderItems)
             .ToListAsync();
        }
        public async Task AddOrderAsync(OrderModel order)
        {
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateOrderAsync(OrderModel order)
        {
            _context.Orders.Update(order);
            await _context.SaveChangesAsync();
        }

        public async Task CreateOrderAsync(OrderModel order)
        {
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteOrderAsync(int id )
        {
            var order = await _context.Orders.FindAsync(id);
            if(order != null)
            {
                _context.Orders.Remove(order);
                await _context.SaveChangesAsync();
            }
        }

        
    }
}