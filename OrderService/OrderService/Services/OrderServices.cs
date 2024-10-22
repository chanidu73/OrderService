using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrderService.Models;
using OrderService.Repositories;

namespace OrderService.Services
{
    public class OrderServices:IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderServices(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public async Task<OrderModel> GetOrderByIdAsync(int orderId)
        {
            return await _orderRepository.GetOrderByIdAsync(orderId);
        }
        public async Task<IEnumerable<OrderModel>>GetAllOrdersAsync()
        {
            return await _orderRepository.GetAllOrdersAsync();
        }
        public async Task CreateOrderAsync(OrderModel order)
        {
            await _orderRepository.CreateOrderAsync(order);
        }
        public async Task DeleteOrderAsync(int orderId)
        {
            // var order = await _orderRepository.GetOrderByIdAsync(orderId);
            await _orderRepository.DeleteOrderAsync(orderId);
        
        }
        public async Task UpdateOrderAsync(OrderModel order)
        {
            await _orderRepository.UpdateOrderAsync(order);
        }
    }
}