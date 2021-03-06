﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalProject.Models.Entities;
using FinalProject.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Controllers
{
    [Route("api/userinfo")]
    public class UserInfoController : Controller
    {
        readonly IService<UserInfo> service;

        public UserInfoController(IService<UserInfo> service)
        {
            this.service = service;
        }
        [HttpGet]
        public List<UserInfo> Get()
        {
            return service
                .GetQuery()
                .Where(x => x.Id > 1)
                .ToList();
        }

        [HttpGet("{id}")]
        public async Task<UserInfo> Get(int id)
        {
            return await service.FindByIdAsync(id);
        }

        [HttpPost("save")]
        public List<UserInfo> Post([FromBody] UserInfo value)
        {
            return service
                .GetAll()
                .Where(x => x.PhoneNumber.Contains(value.PhoneNumber) ||
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
