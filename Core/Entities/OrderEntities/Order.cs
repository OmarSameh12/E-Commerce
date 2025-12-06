using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.OrderEntities
{

    public enum OrderStatus {
        pending,
        PaymentFailed,
        PaymentSucceeded,
    
    }
    public class Order:BaseEntity
    {
        public string  BuyerEmail { get; set; }

        public DateTimeOffset OrderDate { get; set; }= DateTimeOffset.Now;
        public ShippingAddress ShippingAddress  { get; set; }
        public DeliverMethod DeliverMethod { get; set; }

        public OrderStatus OrderStatus  { get; set; }
        public IReadOnlyList<OrderItem> OrderItems { get; set; }

        public decimal  SubTotal { get; set; }
        public decimal GetTotal() =>
            SubTotal + DeliverMethod.Price;








    }
}
