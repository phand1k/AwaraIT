using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwaraIT.Models
{
    public class OrderHistory
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public DateTime Date { get; set; }

        public OrderHistory(int orderId, int productId, int quantity, DateTime date)
        {
            OrderId = orderId;
            ProductId = productId;
            Quantity = quantity;
            Date = date;
        }
    }
}
