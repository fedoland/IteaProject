﻿using FinalProject.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Models.Entities
{
    public class UserInfo : IProjectModel
    {
        [Key] public int Id { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int UserId { get; set; }
        public UserAddress UserAddress { get; set; }
        [ForeignKey("UserId")] public User User { get; set; }
    }
}
