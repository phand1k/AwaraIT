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
    public class OrderHistoryRepository : IOrderHistoryRepository
    {
        private List<OrderHistory> _orderHistory = new List<OrderHistory>();

        public IEnumerable<OrderHistory> GetAllOrderHistories()
        {
            return _orderHistory;
        }

        public void AddOrderHistory(OrderHistory order)
        {
            _orderHistory.Add(order);
        }

        public void LoadOrderHistoryFromFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                string jsonData = File.ReadAllText(filePath);
                _orderHistory = JsonSerializer.Deserialize<List<OrderHistory>>(jsonData);
            }

            else
            {
                _orderHistory = new List<OrderHistory>
            {
                new OrderHistory(1, 1, 2, DateTime.Now.AddDays(-2)), 
                new OrderHistory(2, 2, 1, DateTime.Now.AddDays(-1))
            };
                SaveOrderHistoryToFile(filePath);
            }
        }

        public void SaveOrderHistoryToFile(string filePath)
        {
            string jsonData = JsonSerializer.Serialize(_orderHistory);
            File.WriteAllText(filePath, jsonData);
        }
    }
}
