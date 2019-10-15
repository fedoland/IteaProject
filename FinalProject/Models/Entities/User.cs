using FinalProject.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Models.Entities
{
    public class User : IProjectModel
    {
        [Key] public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public List<LoginHistory> Logins { get; set; }
        public UserInfo UserInfo { get; set; }
    }
}
