using DAL.Repositories;
using ENTITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Abstract
{
    public interface ICartService
    {
        Task<int> AddToCartAsync(CartItem cartItem);
        Task<Cart> GetCartByUserIdAsync(string userId);
        void ClearCart(int cartId);
    }
}
