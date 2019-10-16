using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalProject.Models.Abstract;
using FinalProject.Models.Database;
using FinalProject.Models.Entities;
using FinalProject.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Services
{
    public class UserService : IService<User>
    {
        public Repository<User> Repository { get; set; }
        public UserService(ProjectDbContext dbContext)
        {
            Repository = new Repository<User>(dbContext);
        }
        public void Create(User item)
        {
            Repository.Create(item);
        }

        public void Delete(User id)
        {
            Repository.Remove(id);
        }

        public User FindById(int id)
        {
           return Repository.FindById(id);
        }

        public List<User> GetAll()
        {
            return Repository.GetAll().ToList();
        }

        public IQueryable<User> GetQuery()
        {
            return Repository.GetAll();
        }

        public User Update(int id, User updatedItem)
        {
            Repository.Update(updatedItem);
            return updatedItem;
        }
    }
}
