using AwaraIT.Repositories.Interfaces;
using AwaraIT.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwaraIT
{
    public class AdminPanel
    {
        private readonly IProductService _productService;
        private readonly IStockService _stockService;

        public AdminPanel(IProductService productService, IStockService stockService)
        {
            _productService = productService;
            _stockService = stockService;
        }

        public void DisplayAdminMenu()
        {
            while (true)
            {
                Console.WriteLine("\nАдмин меню:");
                Console.WriteLine("1. Просмотреть список товаров");
                Console.WriteLine("2. Изменить остаток товара");
                Console.WriteLine("3. Сохранить изменения и выйти");
                Console.WriteLine("4. Выйти без сохранения");

                Console.Write("Выберите опцию: ");
                var input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        DisplayProducts();
                        break;
                    case "2":
                        UpdateProductStock();
                        break;
                    case "3":
                        SaveProductsAndExit();
                        return;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("Неверный ввод. Попробуйте снова.");
                        break;
                }
            }
        }

        private void DisplayProducts()
        {
            var products = _productService.GetAllProducts();
            var stocks = _stockService.GetAllStocks();
            Console.WriteLine("\nСписок товаров:");

            foreach (var product in products)
            {
                var stock = stocks.FirstOrDefault(s => s.ProductId == product.Id)?.Quantity ?? 0;
                Console.WriteLine($"ID: {product.Id}, Название: {product.Name}, Цена: {product.Price:C}, Остаток: {stock}");
            }
        }

        private void UpdateProductStock()
        {
            Console.Write("Введите ID товара для изменения остатка: ");
            if (int.TryParse(Console.ReadLine(), out int productId))
            {
                Console.Write("Введите количество для изменения (например, +5 или -3): ");
                if (int.TryParse(Console.ReadLine(), out int stockChange))
                {
                    _stockService.UpdateProductStock(productId, stockChange);
                }
                else
                {
                    Console.WriteLine("Некорректное количество.");
                }
            }
            else
            {
                Console.WriteLine("Некорректный ID.");
            }
        }

        private void SaveProductsAndExit()
        {
            Console.WriteLine("Сохранение изменений...");
            _stockService.SaveChanges();
            Console.WriteLine("Изменения сохранены.");
        }
    }


}
