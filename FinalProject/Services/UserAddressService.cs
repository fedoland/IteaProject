﻿using FinalProject.Models.Abstract;
using FinalProject.Models.Database;
using FinalProject.Models.Entities;
using FinalProject.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Services
{
    public class UserAddressService : IService<UserAddress>
    {
        public Repository<UserAddress> Repository { get; set; }
        public AsyncRepository<UserAddress> asyncRepository { get; set; }
        public UserAddressService(ProjectDbContext dbContext)
        {
            Repository = new Repository<UserAddress>(dbContext);
        }
        public void Create(UserAddress item)
        {
            Repository.Create(item);
        }
        public async Task CreateAsync(UserAddress item)
        {
            await asyncRepository.CreateAsync(item);
        }
        public void Delete(UserAddress id)
        {
            Repository.Remove(id);
        }
        public async Task DeleteAsync(UserAddress id)
        {
            await asyncRepository.RemoveAsync(id);
        }
        public UserAddress FindById(int id)
        {
            return Repository.FindById(id);
        }
        public async Task<UserAddress> FindByIdAsync(int id)
        {
            return await asyncRepository.FindById(id);
        }
        public List<UserAddress> GetAll()
        {
            return Repository.GetAll().ToList();
        }

        public IQueryable<UserAddress> GetQuery()
        {
            return Repository.GetAll();
        }

        public UserAddress Update(int id, UserAddress updatedItem)
        {
            Repository.Update(updatedItem);
            return updatedItem;
        }
        public async Task UpdateAsync(int id, UserAddress updatedItem)
        {
            await asyncRepository.UpdateAsync(updatedItem);
        }
    }
}
