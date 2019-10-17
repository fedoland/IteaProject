using FinalProject.Models.Abstract;
using FinalProject.Models.Database;
using FinalProject.Models.Entities.ManyToMany;
using FinalProject.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Services.ManyToManyServices
{
    public class CourseService : IService<Course>
    {
        public Repository<Course> Repository { get; set; }
        public AsyncRepository<Course> asyncRepository { get; set; }
        public CourseService(ProjectDbContext dbContext)
        {
            Repository = new Repository<Course>(dbContext);
        }
        public void Create(Course item)
        {
            Repository.Create(item);
        }
        public async Task CreateAsync(Course item)
        {
            await asyncRepository.CreateAsync(item);
        }
        public void Delete(Course id)
        {
            Repository.Remove(id);
        }
        public async Task DeleteAsync(Course id)
        {
            await asyncRepository.RemoveAsync(id);
        }
        public Course FindById(int id)
        {
            return Repository.FindById(id);
        }
        public async Task<Course> FindByIdAsync(int id)
        {
            return await asyncRepository.FindById(id);
        }

        public List<Course> GetAll()
        {
            return Repository.GetAll().ToList();
        }

        public IQueryable<Course> GetQuery()
        {
            return Repository.GetAll();
        }

        public Course Update(int id, Course updatedItem)
        {
            Repository.Update(updatedItem);
            return updatedItem;
        }
        public async Task UpdateAsync(int id, Course updatedItem)
        {
            await asyncRepository.UpdateAsync(updatedItem);
        }
    }
}
