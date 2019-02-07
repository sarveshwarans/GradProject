using SchoolDBAssignment6.Repositry;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SchoolDBAssignment6
{
    public class RepositrySchool<T>:IRepositry<T> where T:class
    {
        protected DbContext dbContext;
        public RepositrySchool(DbContext schoolcontext)
        {
            dbContext = schoolcontext;
        }

        public void Insert(T entity)
        {
            dbContext.Entry(entity).State = EntityState.Added;
            dbContext.SaveChanges();
        }
        public void Delete(T entity)
        {
            dbContext.Set<T>().Remove(entity);
            dbContext.SaveChanges();
        }
        //public void Update(T entity)
        //{
        //    dbContext.Entry(entity).State = EntityState.Modified;
        //    dbContext.SaveChanges();
        //}
        public void Dispose()
        {
            throw new NotImplementedException();
        }
        public IEnumerable<T> GetAll()
        {
            return dbContext.Set<T>();
        }

        public T GetById(int id)
        {
            return dbContext.Set<T>().Find(id);
        }

        public T GetSingle(Func<T, bool> where, params Expression<Func<T, object>>[] navigationProperties)
        {
            T item = null;
            IQueryable<T> dbQuery = dbContext.Set<T>();
            foreach (Expression<Func<T, object>> navigationProperty in navigationProperties)
                dbQuery = dbQuery.Include<T, object>(navigationProperty);
            item = dbQuery.AsNoTracking().FirstOrDefault(where);
            return item;
        }

        

        public IQueryable<T> SearchFor(Expression<Func<T, bool>> predicate)
        {
            return dbContext.Set<T>().Where(predicate);
        }

        public void SaveChanges()
        {
            dbContext.SaveChanges();
        }
    }
}
