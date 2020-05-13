using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crowdfunding_API.Entities
{
    public class File
    {
        public int ID { get; set; }
        public Project Project_ID { get; set; }

        public string Value { get; set; }
    }
}
