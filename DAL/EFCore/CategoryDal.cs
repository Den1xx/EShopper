using DAL.EFCore.Context;
using ENTITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EFCore
{
    public class CategoryDal : Repository<Category, DataContext>
    {
        private readonly DataContext _context;
        public CategoryDal(DataContext context) : base(context)
        {

        }

    }
}
