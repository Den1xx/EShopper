﻿using BLL.Abstract;
using DAL.EFCore.Abstract;
using DAL.Repositories;
using ENTITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Concrete
{
    public class ProductService : IProductService
    {
        private IProductDal _productDal;
        public ProductService(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public int Create()
        {
            throw new NotImplementedException();
        }

        public int Delete()
        {
            throw new NotImplementedException();
        }

        public Product Find(int id)
        {
            return _productDal.Find(id);
        }

        public List<Product> GetAll()
        {
            return _productDal.GetAll();
        }

        public List<Product> GetOne(Expression<Func<Product, bool>> filter)
        {
            return _productDal.GetOne(filter);
        }

        public int Update()
        {
            throw new NotImplementedException();
        }
    }
}
