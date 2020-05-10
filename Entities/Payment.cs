using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Crowdfunding_API.Entities
{
    public class Payment
    {
        public int ID { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Card_name { get; set; }

        [Required]
        public int Card_number { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 3)]
        public int Month { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public int CVC { get; set; }

        [Required]
        public int Amount { get; set; }

        [Required]
        public string Curency { get; set; }

        [Required] 
        public string Payment_method { get; set; }

        //Creating Foreign Key User_ID 
        public User User { get; set; }

        public Project Project { get; set; }
    }
}
