using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crowdfunding_API.Entities
{
    public class FavoriteProjects
    { 
        public User User { get; set; }

        public Project Project { get; set; }
    }
}
