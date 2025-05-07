using BLL.Abstract;
using DAL.EFCore.Abstract;
using ENTITY;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Concrete
{
    public class BrandService : IBrandService
    {
        private IBrandDAl _brandDal;
        public BrandService(IBrandDAl brandDal)
        {
            _brandDal = brandDal;
        }

        public int Create()
        {
            throw new NotImplementedException();
        }

        public int Delete()
        {
            throw new NotImplementedException();
        }

        public Brand Find(int id)
        {
            throw new NotImplementedException();
        }

        public List<Brand> GetAll()
        {
            return _brandDal.GetAll();
        }

        public List<Brand> GetOne(Expression<Func<Brand, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public int Update()
        {
            throw new NotImplementedException();
        }
    }
}
