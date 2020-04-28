using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Crowdfunding_API.Entities;

namespace Crowdfunding_API
{
    public class ApplicationDBContext : DbContext 
    {
        public ApplicationDBContext (DbContextOptions<ApplicationDBContext> options) : base(options)
        {
        }

        public DbSet<Project> Project { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Role> Role { get; set; }

        //public DbSet<Payments> Payments { get; set; }
        //public DbSet<ProjectsPayments> ProjectsPayments { get; set; }
        //public DbSet<ProjectsUsers> ProjectsUsers { get; set; }
        //public DbSet<ProjectsFiles> ProjectsFiles { get; set; }
        //public DbSet<UsersRoles> UsersRoles { get; set; }
    }


}
