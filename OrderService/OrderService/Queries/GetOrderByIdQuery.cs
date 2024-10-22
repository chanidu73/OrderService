using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using OrderService.Models;

namespace OrderService.Queries
{
    public class GetOrderByIdQuery:IRequest<OrderModel>
    {
        public int OrderId { get;set; }
        public GetOrderByIdQuery(int orderId)
        {
            OrderId = orderId;
        }
    }
}