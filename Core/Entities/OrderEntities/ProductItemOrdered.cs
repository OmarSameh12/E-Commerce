using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.OrderEntities
{
    public class ProductItemOrdered
    {
        public int ProductItemId { get; set; }

        public string  ProductName { get; set; }

        public string PictureUrl { get; set; }
    }
}
