﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FinalProject.Models.Interfaces
{
    public interface IRepository<T>
    {
        void Create(T item);
        T FindById(int id);
        IQueryable<T> Get(Expression<Func<T, bool>> predicate);
        IQueryable<T> GetAll();
        void Remove(T item);
        void Update(T item);
    }
}
