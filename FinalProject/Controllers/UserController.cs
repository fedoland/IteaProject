using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalProject.Models.Entities;
using FinalProject.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        readonly IService<User> service;

        public UserController(IService<User> service)
        {
            this.service = service;
        }

        [HttpGet]
        public List<User> Get()
        {
            return service
                .GetQuery()
                .Include(x => x.UserInfo)
                    .ThenInclude(x => x.UserAddress)
                .Include(logs => logs.Logins)
                .Where(x => x.UserInfo.UserAddress.RealName == "Vasya")
                .ToList();
        }

        [HttpGet("{id}")]
        public User Get(int id)
        {
            return service.FindById(id);
        }

        [HttpPost("save")]
        public List<User> Post([FromBody] User value)
        {
            return service
                .GetAll()
                .Where(x => x.Password.Contains(value.Password) ||
                            x.Username.Contains(value.Username) ||
                            x.Id == value.Id)
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