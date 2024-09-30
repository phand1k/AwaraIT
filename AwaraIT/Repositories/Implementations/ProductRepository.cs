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
    public class ProductRepository : IProductRepository
    {
        private List<Product> _products = new List<Product>();

        public IEnumerable<Product> GetAllProducts()
        {
            return _products;
        }

        public void LoadProductsFromFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                string jsonData = File.ReadAllText(filePath);
                _products = JsonSerializer.Deserialize<List<Product>>(jsonData);
            }
            else
            {
                _products = new List<Product>
            {
                new Product(1, "Товар 1", 100.0m),
                new Product(2, "Товар 2", 150.0m),
                new Product(3, "Товар 3", 200.0m)
            };
                SaveProductsToFile(filePath);
            }
        }

        public void SaveProductsToFile(string filePath)
        {
            string jsonData = JsonSerializer.Serialize(_products);
            File.WriteAllText(filePath, jsonData);
        }
    }

}
