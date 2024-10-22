using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using OrderService.Models;

namespace OrderService.Commands
{
    public class CreateOrderCommand:IRequest<bool>
    {
        public int CustormerId { get;set; }
        public List<OrderItemModel>OrderItems { get;set; }
        public CreateOrderCommand (int custormerId , List<OrderItemModel> orderItems)
        {
            CustormerId = custormerId;
            OrderItems = orderItems;
        } 
    }
    
}