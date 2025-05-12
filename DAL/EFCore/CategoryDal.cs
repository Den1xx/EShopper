using DAL.EFCore.Abstract;
using DAL.EFCore.Context;
using Microsoft.EntityFrameworkCore;
using ENTITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EFCore
{
    public class CategoryDal : Repository<Category, DataContext>, ICategoryDal
    {
        private readonly DataContext _context;
        public CategoryDal(DataContext context) : base(context)
        {
            _context = context;
        }
        public List<Category> GetAll()
        {
            return _context.Categories.Include(i => i.BrandCategories).ThenInclude(i => i.Brand).ToList();
        }

    }
}
