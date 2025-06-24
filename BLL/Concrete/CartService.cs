using BLL.Abstract;
using ENTITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Concrete
{
    public class CartService : ICartService
    {
        public Task<int> AddToCartAsync(CartItem cartItem)
        {
            throw new NotImplementedException();
        }

        public void ClearCart(int cartId)
        {
            throw new NotImplementedException();
        }

        public Task<Cart> GetCartByUserIdAsync(string userId)
        {
            throw new NotImplementedException();
        }
    }
}
