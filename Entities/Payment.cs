using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Crowdfunding_API.Entities
{
    public class Payment
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Card_name { get; set; }

        [Required]
        public long Card_number { get; set; }

        [Required]
        public string Month { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public int CVV { get; set; }

        [Required]
        public long Amount { get; set; }

        [Required]
        public string Currency { get; set; } 

        [Required] 
        public string Payment_method { get; set; }

        //Creating Foreign Key User_ID 
        public User User { get; set; }

        public Project Project { get; set; }
    }
}
