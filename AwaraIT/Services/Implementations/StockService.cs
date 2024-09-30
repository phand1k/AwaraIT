using AwaraIT.Models;
using AwaraIT.Repositories.Interfaces;
using AwaraIT.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwaraIT.Services.Implementations
{
    public class StockService : IStockService
    {
        private readonly IStockRepository _stockRepository;

        public StockService(IStockRepository stockRepository)
        {
            _stockRepository = stockRepository;
        }

        public IEnumerable<Stock> GetAllStocks()
        {
            return _stockRepository.GetAllStocks();
        }

        public void UpdateProductStock(int productId, int stockChange)
        {
            var stock = _stockRepository.GetAllStocks().FirstOrDefault(s => s.ProductId == productId);
            if (stock != null)
            {
                stock.Quantity += stockChange;
            }
            else
            {
                _stockRepository.GetAllStocks().Append(new Stock(productId, stockChange));
            }
        }

        public void SaveChanges()
        {
            _stockRepository.SaveStocksToFile("stock.json");
        }
    }
}
