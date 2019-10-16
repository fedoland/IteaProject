using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalProject.Models.Entities;
using FinalProject.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Controllers
{
    [Route("api/useraddress")]
    [ApiController]
    public class UserAddressController : ControllerBase
    {
        readonly IService<UserAddress> service;

        public UserAddressController(IService<UserAddress> service)
        {
            this.service = service;
        }

        [HttpGet]
        public List<UserAddress> Get()
        {
            return service
                .GetQuery()
                .Where(x => x.Id > 0)
                .ToList();
        }

        [HttpGet("{id}")]
        public UserAddress Get(int id)
        {
            return service.FindById(id);
        }

        [HttpPost("save")]
        public List<UserAddress> Post([FromBody] UserAddress value)
        {
            return service
                .GetAll()
                .Where(x => x.RealName.Contains(value.RealName) ||
                            x.Address.Contains(value.Address) ||
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