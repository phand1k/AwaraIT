using AwaraIT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwaraIT.Services.Interfaces
{
    public interface IStockService
    {
        IEnumerable<Stock> GetAllStocks();
        void UpdateProductStock(int productId, int stockChange);
        void SaveChanges();
    }

}
