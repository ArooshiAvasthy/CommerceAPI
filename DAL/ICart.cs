using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface ICart
    {
        List<Cart> DisplayCart(string name);
        void AddToCart(string Title, int Quantity, string Username);
        List<Cart> AddToCartDisplay(string Username);
        void GetClearItem(int id);
    }
}
