using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalProject.Models.Entities.ManyToMany;
using FinalProject.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Controllers.ManyToManyControllers
{
    [Route("api/course")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        readonly IService<Course> service;

        public CourseController(IService<Course> service)
        {
            this.service = service;
        }

        [HttpGet]
        public List<Course> Get()
        {
            return service
                .GetQuery()
                .Where(x => x.CourseId > 0)
                .ToList();
        }

        [HttpGet("{id}")]
        public Course Get(int id)
        {
            return service.FindById(id);
        }

        [HttpPost("save")]
        public List<Course> Post([FromBody] Course value)
        {
            return service
                .GetAll()
                .Where(x => x.CourseName.Contains(value.CourseName))
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