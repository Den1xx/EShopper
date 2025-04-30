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
    public class Repository<T, TContext> : IRepository<T> where T : class where TContext : DbContext, new()
    {
        public T Find(int id)
        {
            using (var db = new TContext())
            {
                return db.Set<T>().Find(id);
            }
        }

        public List<T> GetAll()
        {
            using (var db = new TContext())
            {
               return db.Set<T>().ToList();
            }
        }

        public List<T> GetOne(Expression<Func<T, bool>> filter)
        {
            using (var db = new TContext())
            {
                return db.Set<T>().Where(filter).ToList();
            }
        }
        public int Create(T entity)
        {
            using (var db = new TContext())
            {
                db.Set<T>().Add(entity);
                return db.SaveChanges();
            }
        }
        public int Delete(T entity)
        {
            using (var db = new TContext())
            {
                db.Set<T>().Remove(entity);
                return db.SaveChanges();
            }
        }

        public int Update(T entity)
        {
            using (var db = new TContext())
            {
                
                return db.SaveChanges();
            }
        }
    }
}
