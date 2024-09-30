using AwaraIT.Models;
using AwaraIT.Repositories.Interfaces;
using AwaraIT.Services.Interfaces;
using System;

namespace AwaraIT
{
    public class ClientMenu
    {
        private readonly IProductService _productService;
        private readonly ICartService _cartService;
        private readonly IStockService _stockService;
        private readonly IOrderHistoryRepository _orderHistoryRepository;

        public ClientMenu(IProductService productService, ICartService cartService, IStockService stockService, IOrderHistoryRepository orderHistoryRepository)
        {
            _productService = productService;
            _cartService = cartService;
            _stockService = stockService;
            _orderHistoryRepository = orderHistoryRepository;
        }

        public void DisplayMenu()
        {
            while (true)
            {
                Console.WriteLine("\nГлавное меню:");
                Console.WriteLine("1. Просмотреть список товаров");
                Console.WriteLine("2. Добавить товар в корзину");
                Console.WriteLine("3. Удалить товар из корзины");
                Console.WriteLine("4. Просмотреть текущую корзину");
                Console.WriteLine("5. Выйти");

                Console.Write("Выберите опцию: ");
                var input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        DisplayProducts();
                        break;
                    case "2":
                        AddProductToCart();
                        break;
                    case "3":
                        RemoveProductFromCart();
                        break;
                    case "4":
                        _cartService.DisplayCart();
                        break;
                    case "5":
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

        private void AddProductToCart()
        {
            Console.Write("Введите ID товара для добавления в корзину: ");
            if (int.TryParse(Console.ReadLine(), out int productId))
            {
                var stock = _stockService.GetAllStocks().FirstOrDefault(s => s.ProductId == productId)?.Quantity ?? 0;
                var product = _productService.GetAllProducts().FirstOrDefault(p => p.Id == productId);

                if (product != null && stock > 0)
                {
                    _cartService.AddProductToCart(product);
                    _stockService.UpdateProductStock(productId, -1); 
                    _orderHistoryRepository.AddOrderHistory(new OrderHistory(
                        new Random().Next(1000, 9999), 
                        productId,
                        1,
                        DateTime.Now));

                    _orderHistoryRepository.SaveOrderHistoryToFile("orderHistory.json");
                    Console.WriteLine("Товар успешно добавлен в корзину и история обновлена.");
                }
                else
                {
                    Console.WriteLine("Недостаточно товара на складе или неверный ID.");
                }
            }
            else
            {
                Console.WriteLine("Некорректный ID.");
            }
        }

        private void RemoveProductFromCart()
        {
            Console.Write("Введите ID товара для удаления из корзины: ");
            if (int.TryParse(Console.ReadLine(), out int productId))
            {
                var product = _productService.GetAllProducts().FirstOrDefault(p => p.Id == productId);

                if (product != null)
                {
                    _cartService.RemoveProductFromCart(product);
                    _stockService.UpdateProductStock(productId, 1); 
                    Console.WriteLine("Товар успешно удален из корзины.");
                }
                else
                {
                    Console.WriteLine("Товар не найден.");
                }
            }
            else
            {
                Console.WriteLine("Некорректный ID.");
            }
        }
    }
}
