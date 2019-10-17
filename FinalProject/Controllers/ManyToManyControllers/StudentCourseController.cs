using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalProject.Models.Entities.ManyToMany;
using FinalProject.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Controllers.ManyToManyControllers
{
    [Route("api/studentcourse")]
    [ApiController]
    public class StudentCourseController : ControllerBase
    {
        readonly IService<StudentCourse> service;

        public StudentCourseController(IService<StudentCourse> service)
        {
            this.service = service;
        }

        [HttpGet]
        public List<StudentCourse> Get()
        {
            return service
                .GetQuery()
                .Include(x=> x.Course)
                .Include(x=> x.Student)
                .Where(x => x.StudentId > 0 &&
                x.CourseId > 0)
                .ToList();
        }

        [HttpGet("{id}")]
        public StudentCourse Get(int id)
        {
            return service.FindById(id);
        }

        [HttpPost("save")]
        public List<StudentCourse> Post([FromBody] StudentCourse value)
        {
            return service
                .GetAll()
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