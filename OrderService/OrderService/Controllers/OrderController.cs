using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using OrderService.Commands;
using OrderService.Models;
using OrderService.Queries;
using OrderService.Services;

namespace OrderService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController:ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService order)
        {
            _orderService = order;
        } 
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderModel>>> GetAllOrders()
        {
            var orders = await _orderService.GetAllOrdersAsync();
            return Ok(orders);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderModel>> GetOrderById(int id)
        {
            var order = await _orderService.GetOrderByIdAsync(id);
            if(order== null)return NotFound("There is no called as Input");
            return Ok(order);
        }
        [HttpPost]
        public async Task<ActionResult<OrderModel>> CreateOrder([FromBody] OrderModel order)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest("Please Try Again To  Create again ");
            }
            await _orderService.CreateOrderAsync(order);
            return CreatedAtAction(nameof(GetOrderById) , new {id = order.OrderId});
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrder(int id , [FromBody] OrderModel order)
        {
            if(id!= order.OrderId)return NotFound("There is No Order Like That ");
            await _orderService.UpdateOrderAsync(order);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult>DeleteOrder(int id)
        {
            var order =  await _orderService.GetOrderByIdAsync(id);
            if(order==null)return NotFound("There is no order Called that ");
            await _orderService.DeleteOrderAsync(id);
            return NoContent();
        }
    }
}

// add program file to map controllers and stuff and also make sure to make migrations 


/*        private readonly IMediator _mediator;
        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("create")]
        public async Task<IActionResult>CreateOrder([FromBody]CreateOrderCommand command)
        {
            var result = await _mediator.Send(command); 
            if(!result)return BadRequest("Faild To Create Order ");
            return Ok("Order  Created Successfully");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult>GetOrderById (int id)
        {
            var query =new GetOrderByIdQuery(id);
            var order = await _mediator.Send(query);
            if(order == null)return NotFound("There is no Order like that ");
            return Ok(order);
        }*/