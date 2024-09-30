using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwaraIT.Models
{
    public class Transaction
    {
        public int Id { get; private set; }
        public int Amount { get; private set; }
        public int ProductId { get; private set; }

        public Transaction(int id, int amount, int productId)
        {
            Id = id;
            Amount = amount;
            ProductId = productId;
        }
    }
}
