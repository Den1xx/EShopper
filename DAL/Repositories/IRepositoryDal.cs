using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public interface IRepositoryDal<T> where T : class
    {
        int Create(T entity);
        int Update();
        int Delete(int id);
        List<T>GetAll();
        List<T>GetOne(Expression<Func<T,bool>> filter);
        T Find(int id);
    }
}
