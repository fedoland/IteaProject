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
        public UserInfoService(ProjectDbContext dbContext)
        {
            Repository = new Repository<UserInfo>(dbContext);
        }
        public void Create(UserInfo item)
        {
            Repository.Create(item);
        }

        public void Delete(UserInfo id)
        {
            Repository.Remove(id);
        }

        public UserInfo FindById(int id)
        {
            return Repository.FindById(id);
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
    }
}
