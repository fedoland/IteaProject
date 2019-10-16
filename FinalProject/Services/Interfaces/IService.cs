using FinalProject.Models.Abstract;
using FinalProject.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Services.Interfaces
{
    public interface IService<T> where T : class, IProjectModel
    {
        Repository<T> Repository { get; set; }
        List<T> GetAll();
        T FindById(int id);
        void Create(T item);
        void Delete(T id);
        T Update(int id, T updatedItem);
        IQueryable<T> GetQuery();
    }
}
