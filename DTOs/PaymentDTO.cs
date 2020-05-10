using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crowdfunding_API.DTOs
{
    public class PaymentDTO
    {
        public int ID { get; set; }
        public string Card_name { get; set; }
        
        public int Card_number { get; set; }
       
        public int Month { get; set; }

        public int Year { get; set; }
 
        public int CVC { get; set; }

        public int Amount { get; set; }

        public string Curency { get; set; }

        public string Payment_method { get; set; }
    }
}
