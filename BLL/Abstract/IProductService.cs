using ENTITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Abstract
{
    public interface IProductService
    {
        int Create(Product entity);
        int Update(Product updateProduct, List<Image> images);
        void Delete(Product entity);
        List<Product> GetAll();
        List<Product> GetOne(Expression<Func<Product, bool>> filter);
        Product Find(int id);
    }
}
