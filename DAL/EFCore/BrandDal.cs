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
    public class BrandDal : Repository<Brand,DataContext> , IBrandDAl
    {
        private readonly DataContext _context;

        public BrandDal(DataContext context) : base(context)
        {
            _context = context;

        }
        public override List<Brand> GetAll()
        {
            
                return _context.Brands.Include("Products").ToList();
            
        }

    }
}
