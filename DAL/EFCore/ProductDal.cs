using DAL.EFCore.Abstract;
using DAL.EFCore.Context;
using DAL.Repositories;
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
    public class ProductDal : RepositoryDal<Product, DataContext>, IProductDal
    {
        private readonly DataContext _context;
        public ProductDal(DataContext context) : base(context)
        {


        }
        
    }
}
