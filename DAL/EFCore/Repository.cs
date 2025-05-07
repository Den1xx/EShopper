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
    public class Repository<T, TContext> : IRepository<T> where T : class where TContext : DbContext
    {
        private readonly TContext _context;

        public Repository(TContext context)
        {
            _context = context;
        }

        public T Find(int id) => _context.Set<T>().Find(id);
        public List<T> GetAll() => _context.Set<T>().ToList();
        public List<T> GetOne(Expression<Func<T, bool>> filter) => _context.Set<T>().Where(filter).ToList();
        public int Create(T entity) 
        { 
            _context.Set<T>().Add(entity); return _context.SaveChanges(); 
        }


        public int Delete(T entity) 
        { 
            _context.Set<T>().Remove(entity); return _context.SaveChanges(); 
        }

        public int Update(T entity) 
        { 
            
            return _context.SaveChanges(); 
        }         
    }
}
