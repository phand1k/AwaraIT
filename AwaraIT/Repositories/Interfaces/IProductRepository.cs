using AwaraIT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwaraIT.Repositories.Interfaces
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAllProducts();
        void LoadProductsFromFile(string filePath);
        void SaveProductsToFile(string filePath);
    }
}
