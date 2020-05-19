using Crowdfunding_API.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Crowdfunding_API.DTOs
{
    public class ProjectPatchDTO
    {
        [FirstLetterUpperCase]
        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Title { get; set; }

        [Required]
        public int Goal { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string Country { get; set; }

        [Required]
        public long Account_Number { get; set; }

        [DataType(DataType.Date)]
        public DateTime Duration { get; set; }

        public int UserId { get; set; }
    }
}
