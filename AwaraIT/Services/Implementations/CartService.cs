using AwaraIT.Models;
using AwaraIT.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwaraIT.Services.Implementations
{
    public class CartService : ICartService
    {
        private readonly List<Product> _cart = new List<Product>();

        public void AddProductToCart(Product product)
        {
            _cart.Add(product);
            Console.WriteLine($"{product.Name} добавлен в корзину.");
        }

        public void RemoveProductFromCart(Product product)
        {
            if (_cart.Contains(product))
            {
                _cart.Remove(product);
                Console.WriteLine($"{product.Name} удален из корзины.");
            }
            else
            {
                Console.WriteLine("Товар не найден в корзине.");
            }
        }

        public void DisplayCart()
        {
            if (_cart.Count > 0)
            {
                Console.WriteLine("\nТекущая корзина:");
                foreach (var product in _cart)
                {
                    Console.WriteLine($"{product.Name} - {product.Price:C}");
                }
            }
            else
            {
                Console.WriteLine("Корзина пуста.");
            }
        }
    }
}
