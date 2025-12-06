using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.OrderEntities
{
    public class OrderItem:BaseEntity
    {
        public decimal  Price { get; set; }

        public int Quantity { get; set; }
        public ProductItemOrdered ItemOrdered  { get; set; }
    }
}
