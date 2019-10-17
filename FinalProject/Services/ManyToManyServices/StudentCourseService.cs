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
    public class StudentCourseService : IService<StudentCourse>
    {
        public Repository<StudentCourse> Repository { get; set; }
        public StudentCourseService(ProjectDbContext dbContext)
        {
            Repository = new Repository<StudentCourse>(dbContext);
        }
        public void Create(StudentCourse item)
        {
            Repository.Create(item);
        }

        public void Delete(StudentCourse id)
        {
            Repository.Remove(id);
        }

        public StudentCourse FindById(int id)
        {
            return Repository.FindById(id);
        }

        public List<StudentCourse> GetAll()
        {
            return Repository.GetAll().ToList();
        }

        public IQueryable<StudentCourse> GetQuery()
        {
            return Repository.GetAll();
        }

        public StudentCourse Update(int id, StudentCourse updatedItem)
        {
            Repository.Update(updatedItem);
            return updatedItem;
        }
    }
}
