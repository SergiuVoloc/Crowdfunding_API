using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Crowdfunding_API.DTOs
{
    public class RoleCreationDTO
    {
        [Required]
        public int Value { get; set; }
    }
}
