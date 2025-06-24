using DAL.EFCore.Abstract;
using DAL.EFCore.Context;
using ENTITY;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EFCore
{
    public class CartDal : ICartDal
    {
        private readonly DataContext _context;
        public CartDal(DataContext context)
        {
            _context = context;
        }

        public Task<int> AddToCartAsync(CartItem cartItem)
        {
            var cart = _context.Carts.Include(i => i.CartItems).FirstOrDefault(i => i.Id == cartItem.CartId);

            var item = cart.CartItems.FirstOrDefault(i => i.ProductId == cartItem.ProductId);

            if (item != null)
            {
                item.Quantity += cartItem.Quantity;
            }
            else
            {
                cart.CartItems.Add(cartItem);
            }

            return  _context.SaveChangesAsync();
        }

        public void ClearCart(int cartId)
        {
            throw new NotImplementedException();
        }

        public int Create(Cart entity)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public Task<Cart> GetCartByUserIdAsync(string userId)
        {
            throw new NotImplementedException();
        }

        public List<Cart> GetOne(Expression<Func<Cart, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public int Update()
        {
            throw new NotImplementedException();
        }
    }
}
