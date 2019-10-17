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
        public AsyncRepository<User> asyncRepository { get; set; }
        public UserService(ProjectDbContext dbContext)
        {
            Repository = new Repository<User>(dbContext);
        }
        public void Create(User item)
        {
            Repository.Create(item);
        }
        public async Task CreateAsync(User item)
        {
            await asyncRepository.CreateAsync(item);
        }
        public void Delete(User id)
        {
            Repository.Remove(id);
        }
        public async Task DeleteAsync(User id)
        {
            await asyncRepository.RemoveAsync(id);
        }
        public User FindById(int id)
        {
           return Repository.FindById(id);
        }
        public async Task<User> FindByIdAsync(int id)
        {
            return await asyncRepository.FindById(id);
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
        public async Task UpdateAsync(int id, User updatedItem)
        {
            await asyncRepository.UpdateAsync(updatedItem);
        }
    }
}
