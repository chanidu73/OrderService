using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OrderService.Models
{
    public class OrderModel
    {
        [Key]
        public int OrderId { get;set; }
        public int CustormerId { get;set; }
        public DateTime OrderDate { get;set; }
        public string Status { get;set; }
        public List<OrderItemModel>OrderItems { get;set; }
        
    }
}