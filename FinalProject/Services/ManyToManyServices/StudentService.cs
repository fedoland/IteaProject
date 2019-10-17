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
    public class StudentService : IService<Student>
    {
        public Repository<Student> Repository { get; set; }
        public StudentService(ProjectDbContext dbContext)
        {
            Repository = new Repository<Student>(dbContext);
        }
        public void Create(Student item)
        {
            Repository.Create(item);
        }

        public void Delete(Student id)
        {
            Repository.Remove(id);
        }

        public Student FindById(int id)
        {
            return Repository.FindById(id);
        }

        public List<Student> GetAll()
        {
            return Repository.GetAll().ToList();
        }

        public IQueryable<Student> GetQuery()
        {
            return Repository.GetAll();
        }

        public Student Update(int id, Student updatedItem)
        {
            Repository.Update(updatedItem);
            return updatedItem;
        }
    }
}
