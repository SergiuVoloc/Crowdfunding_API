using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crowdfunding_API.DTOs
{
    public class ProjectDTO
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public int Goal { get; set; }
        public string Country { get; set; }
        public long Account_Number { get; set; }
        public DateTime Duration { get; set; }
    }
}
