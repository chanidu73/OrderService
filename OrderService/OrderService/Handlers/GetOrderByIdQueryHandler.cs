using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using OrderService.Models;
using OrderService.Queries;
using OrderService.Repositories;

namespace OrderService.Handlers
{
    public class GetOrderByIdQueryHandler:IRequestHandler<GetOrderByIdQuery , OrderModel>
    {
        private readonly IOrderRepository _orderRepository;
        public GetOrderByIdQueryHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public async Task<OrderModel>Handle(GetOrderByIdQuery request , CancellationToken cancellationToken)
        {
            return await _orderRepository.GetOrderByIdAsync(request.OrderId);
        }
        
    }
}