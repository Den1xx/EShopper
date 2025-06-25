using BLL.Abstract;
using DAL.EFCore.Abstract;
using ENTITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

        public Task<int> AddToCartAsync(CartItem cartItem)
        {
            throw new NotImplementedException();
        }

        public void ClearCart(int cartId)
        {
            _cartDal.ClearCart(cartId);
        }

        public int Create(Cart entity)
        {
            return _cartDal.Create(entity);
        }

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Cart Find(int id)
        {
            throw new NotImplementedException();
        }

        public List<Cart> GetAll()
        {
            return _cartDal.GetAll();
        }       

        public Task<Cart> GetCartByUserIdAsync(string userId)
        {
            return _cartDal.GetCartByUserIdAsync(userId);
        }

        public List<Cart> GetOne(Expression<Func<Cart, bool>> filter=null)
        {
           return _cartDal.GetOne(filter);
        }

        public int Update()
        {
            throw new NotImplementedException();
        }
    }
}
