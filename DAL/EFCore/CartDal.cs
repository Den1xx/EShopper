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
    public class CartDal : RepositoryDal<Cart,DataContext>,ICartDal
    {
        private readonly DataContext _context;

        public CartDal(DataContext context) : base(context)
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

        public Task<Cart> GetCartByUserIdAsync(string userId)
        {
            throw new NotImplementedException();
        }

        public override List<Cart> GetOne(Expression<Func<Cart, bool>> filter=null)
        {
            if(filter == null)
            {
                return _context.Carts
               .Include(c => c.CartItems)
               .ThenInclude(ci => ci.Product).ToList();
            }
            return _context.Carts
            .Include(c => c.CartItems)
            .ThenInclude(ci => ci.Product)
            .Where(filter)
            .ToList();
        }
    }
}
