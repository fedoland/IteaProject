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
    public class UserInfoService : IService<UserInfo>
    {
        public Repository<UserInfo> Repository { get; set; }
        public AsyncRepository<UserInfo> asyncRepository { get; set; }
        public UserInfoService(ProjectDbContext dbContext)
        {
            //Repository = new Repository<UserInfo>(dbContext);
            asyncRepository = new AsyncRepository<UserInfo>(dbContext);
        }
        public void Create(UserInfo item)
        {
            Repository.Create(item);
        }
        public async Task CreateAsync(UserInfo item)
        {
            await asyncRepository.CreateAsync(item);
        }
        public void Delete(UserInfo id)
        {
            Repository.Remove(id);
        }
        public async Task DeleteAsync(UserInfo id)
        {
            await asyncRepository.RemoveAsync(id);
        }

        public UserInfo FindById(int id)
        {
            return Repository.FindById(id);
        }
        public async Task<UserInfo> FindByIdAsync(int id)
        {
            return await asyncRepository.FindById(id);
        }
        public List<UserInfo> GetAll()
        {
            return Repository.GetAll().ToList();
        }

        public IQueryable<UserInfo> GetQuery()
        {
            return Repository.GetAll();
        }

        public UserInfo Update(int id, UserInfo updatedItem)
        {
            Repository.Update(updatedItem);
            return updatedItem;
        }
        public async Task UpdateAsync(int id, UserInfo updatedItem)
        {
            await asyncRepository.UpdateAsync(updatedItem);
        }
    }
}
