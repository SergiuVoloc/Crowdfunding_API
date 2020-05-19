using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crowdfunding_API.DTOs
{
    public class PaymentDTO
    {
        public int Id { get; set; }
        public string Card_name { get; set; }
        
        public long Card_number { get; set; }
       
        public string Month { get; set; }

        public int Year { get; set; }
 
        public int CVV { get; set; }

        public long Amount { get; set; }

        public string Currency { get; set; }

        public string Payment_method { get; set; }


    }
}
