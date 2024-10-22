using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrderService.Models;

namespace OrderService.Repositories
{
    public interface IOrderRepository
    {
        Task<OrderModel> GetOrderByIdAsync(int id);
        Task<IEnumerable<OrderModel>> GetAllOrdersAsync();
        Task CreateOrderAsync(OrderModel order);
        Task UpdateOrderAsync(OrderModel order);
        Task DeleteOrderAsync(int id);
    }
}