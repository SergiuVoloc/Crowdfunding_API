using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Crowdfunding_API.Models;

namespace Crowdfunding_API.Data
{
    public class ProjectsDB : DbContext
    {
        public ProjectsDB (DbContextOptions<ProjectsDB> options)
            : base(options)
        {
        }

        public DbSet<Crowdfunding_API.Models.Project> Project { get; set; }
    }


}
