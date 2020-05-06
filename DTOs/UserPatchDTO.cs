using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Crowdfunding_API.DTOs
{
    public class UserPatchDTO
    {
        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string Surename { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string Email { get; set; }
    }
}
