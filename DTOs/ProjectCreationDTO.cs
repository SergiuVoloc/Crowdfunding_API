using Crowdfunding_API.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Crowdfunding_API.DTOs
{
    public class ProjectCreationDTO
    {
        [FirstLetterUpperCase]
        [Required]
        [StringLength(100, MinimumLength = 3)]
        // [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        public string Title { get; set; }

        [Required]
        public int Goal { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string Country { get; set; }

        [Required]
        [CreditCard]  // 16 digits
        public long Account_Number { get; set; }

        [DataType(DataType.Date)]
        public DateTime Duration { get; set; }
    }
}
