using AwaraIT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwaraIT.Services.Interfaces
{
    public interface ICartService
    {
        void AddProductToCart(Product product);
        void RemoveProductFromCart(Product product);
        void DisplayCart();
    }
}
