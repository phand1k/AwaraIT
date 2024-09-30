using AwaraIT.Models;
using AwaraIT.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AwaraIT.Repositories.Implementations
{
    public class StockRepository : IStockRepository
    {
        private List<Stock> _stocks = new List<Stock>();

        public IEnumerable<Stock> GetAllStocks()
        {
            return _stocks;
        }

        public void LoadStocksFromFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                string jsonData = File.ReadAllText(filePath);
                _stocks = JsonSerializer.Deserialize<List<Stock>>(jsonData);
            }
            else
            {
                _stocks = new List<Stock>
            {
                new Stock(1, 10), 
                new Stock(2, 5),  
                new Stock(3, 15)  
            };
                SaveStocksToFile(filePath); 
            }
        }

        public void SaveStocksToFile(string filePath)
        {
            string jsonData = JsonSerializer.Serialize(_stocks);
            File.WriteAllText(filePath, jsonData);
        }
    }
}
