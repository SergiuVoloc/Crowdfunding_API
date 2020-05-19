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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>()
                .HasOne<User>(u => u.User)
                .WithMany(p => p.Projects)
                .HasForeignKey(s => s.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<User>()
                .HasOne<Role>(x => x.Role)
                .WithMany(x => x.UserId)
                .HasForeignKey(x => x.RoleId)
                .OnDelete(DeleteBehavior.Cascade);



            base.OnModelCreating(modelBuilder);
        }

   


        public DbSet<Project> Project { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Payment> Payment { get; set; }
        public DbSet<Admin> Admin { get; set; }
        public DbSet<File> File { get; set; }

        //public DbSet<ProjectsPayments> ProjectsPayments { get; set; }
        //public DbSet<ProjectsUsers> ProjectsUsers { get; set; }
        //public DbSet<ProjectsFiles> ProjectsFiles { get; set; }
        //public DbSet<UsersRoles> UsersRoles { get; set; }
    }


}
