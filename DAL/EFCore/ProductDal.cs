using DAL.EFCore.Abstract;
using DAL.EFCore.Context;
using DAL.Repositories;
using ENTITY;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EFCore
{
    public class ProductDal : RepositoryDal<Product, DataContext>, IProductDal
    {
        private readonly DataContext _context;
        public ProductDal(DataContext context) : base(context)
        {
            _context = context;
        }
        public List<Product> GetAll()
        {
            return _context.Products.Include(i => i.Images).ToList();
        }
        public Product Find(int id) {

            //return _context.Products.Include(p => p.Brand);
            return _context.Products
                  .Include(p => p.Brand)
                  .FirstOrDefault(p => p.Id == id);
        }
    }
}
