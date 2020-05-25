using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Crowdfunding_API.Entities
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string Surname { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string Email { get; set; }

        public string Avatar_img { get; set; }

        //Creating Foreign Key User_ID 
        public int RoleId { get; set; }
        public Role Role { get; set; }

        public ICollection<Project> Projects { get; set; }

        public ICollection<Payment> Payments { get; set; }


    }
}
