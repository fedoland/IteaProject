using FinalProject.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Models.Entities
{
    public class UserAddress : IProjectModel
    {
        //This table is for testing ThenInclude
        [Key] public int Id { get; set; }
        public string RealName { get; set; }
        public string Address { get; set; }
        [ForeignKey("UserId")]
        public int UserId { get; set; }
        [ForeignKey("UserId")] public UserInfo UserInfo { get; set; }
    }
}
