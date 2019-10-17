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
        public CourseService(ProjectDbContext dbContext)
        {
            Repository = new Repository<Course>(dbContext);
        }
        public void Create(Course item)
        {
            Repository.Create(item);
        }

        public void Delete(Course id)
        {
            Repository.Remove(id);
        }

        public Course FindById(int id)
        {
            return Repository.FindById(id);
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
    }
}
