using FinalProject.Models.Database;
using FinalProject.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FinalProject.Models.Abstract
{
    public class Repository<T> : IRepository<T> where T : class, IProjectModel
    {
        private readonly ProjectDbContext dbContext;
        protected readonly DbSet<T> dbSet;
        public Repository(ProjectDbContext dbContext)
        {
            this.dbContext = dbContext;
            dbSet = this.dbContext.Set<T>();
        }
        public void Create(T item)
        {
            dbSet.Add(item);
            dbContext.SaveChanges();
        }

        public T FindById(int id)
        {
            return dbSet.Find(id);
        }

        public IQueryable<T> Get(Expression<Func<T, bool>> predicate)
        {
            return dbSet.Where(predicate);
        }

        public IQueryable<T> GetAll()
        {
            return dbSet;
        }

        public void Remove(T item)
        {
            dbSet.Remove(item);
            dbContext.SaveChanges();
        }
        public void Update(T item)
        {
            dbSet.Update(item);
            dbContext.SaveChanges();
        }
    }
}
