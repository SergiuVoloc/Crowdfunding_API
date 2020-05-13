using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crowdfunding_API.Entities
{
    public class Admin
    {
        public int ID { get; set; }
        public string Username { get; set; }

        public Role Role_ID { get; set; }

    }
}
