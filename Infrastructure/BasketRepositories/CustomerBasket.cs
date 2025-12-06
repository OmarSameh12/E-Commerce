using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.BasketRepositories
{
    public class CustomerBasket
    {
        public string Id { get; set; }

        public List<BasketItem> BasektItems { get; set; }

        public int? DeliveryMethodId { get; set; }

        public decimal ShippingPrice { get; set; }

    }
}
