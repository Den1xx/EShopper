using DAL.Repositories;
using ENTITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EFCore.Abstract
{
    public interface IProductDal: IRepositoryDal<Product>
    {
        void Delete(Product entity);
        int Update(Product updateProduct, List<Image> images);
    }
}
