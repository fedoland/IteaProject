using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalProject.Models.Entities.ManyToMany;
using FinalProject.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FinalProject.Controllers.ManyToManyControllers
{
    [Route("api/student")]
    public class StudentController : Controller
    {
        readonly IService<Student> service;

        public StudentController(IService<Student> service)
        {
            this.service = service;
        }

        [HttpGet]
        public List<Student> Get()
        {
            return service
                .GetQuery()
                .Where(x => x.StudentId > 0)
                .ToList();
        }

        [HttpGet("{id}")]
        public Student Get(int id)
        {
            return service.FindById(id);
        }

        [HttpPost("save")]
        public List<Student> Post([FromBody] Student value)
        {
            return service
                .GetAll()
                .Where(x => x.Name.Contains(value.Name))
                .ToList();
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {

        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
