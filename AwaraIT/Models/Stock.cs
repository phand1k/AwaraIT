using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwaraIT.Models
{
    public class Stock
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }

        public Stock(int productId, int quantity)
        {
            ProductId = productId;
            Quantity = quantity;
        }
    }
}
