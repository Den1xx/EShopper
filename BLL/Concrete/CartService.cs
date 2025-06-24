using BLL.Abstract;
using DAL.EFCore.Abstract;
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
        private readonly ICartDal _cartDal;
        public CartService(ICartDal cartDal)
        {
            _cartDal = cartDal;
        }
        public async Task<int> AddToCartAsync(CartItem cartItem)
        {
            return await _cartDal.AddToCartAsync(cartItem);
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
