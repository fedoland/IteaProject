using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FinalProject.Models.Entities
{
    public class LogHis : Controller
    {
        public int LoginHistoryId { get; set; }
        public LoginHistory LoginHistory { get; set; }

        public int UserInfoId { get; set; }
        public UserInfo UserInfo { get; set; }
    }
}
