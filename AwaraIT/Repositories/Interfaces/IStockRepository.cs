using AwaraIT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwaraIT.Repositories.Interfaces
{
    public interface IStockRepository
    {
        IEnumerable<Stock> GetAllStocks();
        void LoadStocksFromFile(string filePath);
        void SaveStocksToFile(string filePath);
    }
}
