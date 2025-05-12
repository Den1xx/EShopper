using ENTITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Abstract
{
    public interface ICategoryService
    {
        int Create();
        int Update();
        int Delete();
        List<Category> GetAll();
        List<Category> GetOne(Expression<Func<Category, bool>> filter);
        Category Find(int id);
    }
}
