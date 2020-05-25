
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
                .HasForeignKey(s => s.UserId);


            modelBuilder.Entity<User>()
                .HasOne<Role>(x => x.Role)
                .WithMany(x => x.UserId)
                .HasForeignKey(x => x.RoleId);
      

            //modelBuilder.Entity<Payment>()
            //    //.HasOne<Project>(x => x.Project)
            //    //.WithMany(x => x.Payments)
            //    //.HasForeignKey(x => x.ProjectId)
            //    //.OnDelete(DeleteBehavior.Cascade);

            //modelBuilder.Entity<User>()
            //    //.HasMany<Payment>(g => g.Payments)
            //    //.WithOne(s => s.User)
            //    //.HasForeignKey(s => s.UserId)
            //    //.OnDelete(DeleteBehavior.Cascade);

            // nu sunt necesare aceste configiurari din motiv ca EF le face automat
            // se pun numai daca numele sunt diochete...

            // de continuat cu relatiile (check if works payment  - user / project )


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
