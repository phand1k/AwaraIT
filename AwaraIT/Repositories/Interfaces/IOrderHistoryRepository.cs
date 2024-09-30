using AwaraIT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwaraIT.Repositories.Interfaces
{
    public interface IOrderHistoryRepository
    {
        IEnumerable<OrderHistory> GetAllOrderHistories();
        void AddOrderHistory(OrderHistory order);
        void LoadOrderHistoryFromFile(string filePath);
        void SaveOrderHistoryToFile(string filePath);
    }
}
