using ENTITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Abstract
{
    public interface IBrandService
    {
        int Create();
        int Update();
        int Delete();
        List<Brand> GetAll();
        List<Brand> GetOne(Expression<Func<Brand, bool>> filter);
        Brand Find(int id);
    }
}
