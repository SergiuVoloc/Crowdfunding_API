using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Crowdfunding_API.Entities
{
    public class Project
    {
        public int ID { get; set; }

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
        //[CreditCard]  // 16 digits
        public long  Account_Number { get; set; }

        [DataType(DataType.Date)]
        public DateTime Duration { get; set; }

        //Creating Foreign Key User_ID 
        public User User { get; set; }

    }


    

}
