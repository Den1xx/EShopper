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
            return _context.Products.Include(c => c.Categories).Include(i => i.Images).Include(b => b.Brand).ToList();
            
        }
        public Product Find(int id) {

            //return _context.Products.Include(p => p.Brand);
            return _context.Products
                  .Include(p => p.Brand)
                  .Include(p => p.Images)
                  .FirstOrDefault(p => p.Id == id);
        }

        public int Update(Product updateProduct, List<Image> Imgs)
        {
            _context.Images.RemoveRange(Imgs);

            
            _context.SaveChanges();
            var product = _context.Products.Find(updateProduct.Id);

            product.WebID = updateProduct.WebID;
            product.Title = updateProduct.Title;
            product.Images.AddRange(updateProduct.Images.Select(i=> new Image() { ProductId=i.ProductId,Url=i.Url}));
            product.BrandId = updateProduct.BrandId;
            product.CategoryId = updateProduct.CategoryId;
            product.ModifiedDate = updateProduct.ModifiedDate;
            product.Price = updateProduct.Price;
            product.Stock = updateProduct.Stock;
            return _context.SaveChanges();
        }

        public void Delete(Product entity)
        {
            
            _context.Set<Product>().Remove(entity);
            _context.SaveChanges();
        }
    }

}
