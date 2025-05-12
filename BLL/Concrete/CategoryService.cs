using BLL.Abstract;
using DAL.EFCore.Abstract;
using ENTITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Concrete
{
    public class CategoryService : ICategoryService
    {
        public ICategoryDal _categoryDal;
        public CategoryService(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }
        public int Create()
        {
            throw new NotImplementedException();
        }

        public int Delete()
        {
            throw new NotImplementedException();
        }

        public Category Find(int id)
        {
            throw new NotImplementedException();
        }

        public List<Category> GetAll()
        {
            return _categoryDal.GetAll();
        }

        public List<Category> GetOne(Expression<Func<Category, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public int Update()
        {
            throw new NotImplementedException();
        }
    }
}
