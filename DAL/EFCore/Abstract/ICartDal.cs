using DAL.Repositories;
using ENTITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EFCore.Abstract
{
    public interface ICartDal : IRepositoryDal<Cart>
    {
        Task<int> AddToCartAsync(CartItem cartItem);
        Task<Cart> GetCartByUserIdAsync(string userId);
        void ClearCart(int cartId);
    }
}
