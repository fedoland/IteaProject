using FinalProject.Models.Abstract;
using FinalProject.Models.Database;
using FinalProject.Models.Entities;
using FinalProject.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Services
{
    public class LoginHistoryService : IService<LoginHistory>
    {
        public Repository<LoginHistory> Repository { get; set; }
        public LoginHistoryService(ProjectDbContext dbContext)
        {
            Repository = new Repository<LoginHistory>(dbContext);
        }
        public void Create(LoginHistory item)
        {
            Repository.Create(item);
        }

        public void Delete(LoginHistory id)
        {
            Repository.Remove(id);
        }

        public LoginHistory FindById(int id)
        {
            return Repository.FindById(id);
        }

        public List<LoginHistory> GetAll()
        {
            return Repository.GetAll().ToList();
        }

        public IQueryable<LoginHistory> GetQuery()
        {
            return Repository.GetAll();
        }

        public LoginHistory Update(int id, LoginHistory updatedItem)
        {
            Repository.Update(updatedItem);
            return updatedItem;
        }
    }
}
