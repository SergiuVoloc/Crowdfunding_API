
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Crowdfunding_API.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Crowdfunding_API
{
    public class ApplicationDbContext : IdentityDbContext 
    {
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>()
                .HasOne<User>(u => u.User)
                .WithMany(p => p.Projects)
                .HasForeignKey(s => s.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<User>()
                .HasOne<Role>(x => x.Role)
                .WithMany(x => x.UserId)
                .HasForeignKey(x => x.RoleId)
                .OnDelete(DeleteBehavior.NoAction);
            
            modelBuilder.Entity<Payment>()
                .HasOne<Project>(x => x.Project)
                .WithMany(x => x.Payments)
                .HasForeignKey(x => x.ProjectId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Payment>()
                .HasOne<User>(x => x.User)
                .WithMany(x => x.Payments)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            // nu sunt obligatorii aceste configiurari din motiv ca EF le face automat
            // se pun numai daca numele sunt diochete...

            modelBuilder.Entity<FavoriteProjects>()
                .HasKey(x => new {x.UserId, x.ProjectId});


            //InitialData(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        //private void InitialData(ModelBuilder modelBuilder)
        //{

        //    var adventure = new Genre() { Id = 4, Name = "Adventure" };
        //    var animation = new Genre() { Id = 5, Name = "Animation" };
        //    var drama = new Genre() { Id = 6, Name = "Drama" };
        //    var romance = new Genre() { Id = 7, Name = "Romance" };

        //    modelBuilder.Entity<Genre>()
        //        .HasData(new List<Genre>
        //        {
        //            adventure, animation, drama, romance
        //        });

        //    var sergiu = new User() { Id = 5, Name = "Sergiu", Surname = "Voloc", Email  = "sergiuvoloc0@gmail.com", RoleId = 1,  DateOfBirth = new DateTime(1962, 01, 17) };
        //    var lenuta = new User() { Id = 6, Name = "Lenuta", Surname = "Marcu", Email = "lenutamarcu@gmail.com" , RoleId = 2, DateOfBirth = new DateTime(1965, 4, 4) };
        //    var igor   = new User() { Id = 7, Name = "Igor", Surname = "Voloc", Email = "igorvoloc@gmail.com", RoleId = 3, DateOfBirth = new DateTime(1981, 06, 13) };


        //    modelBuilder.Entity<User>()
        //        .HasData(new List<User>
        //        {
        //            sergiu, lenuta, igor
        //        });

        //    var endgame = new Movie()
        //    {
        //        Id = 2,
        //        Title = "Avengers: Endgame",
        //        InTheaters = true,
        //        ReleaseDate = new DateTime(2019, 04, 26)
        //    };

        //    var iw = new Movie()
        //    {
        //        Id = 3,
        //        Title = "Avengers: Infinity Wars",
        //        InTheaters = false,
        //        ReleaseDate = new DateTime(2019, 04, 26)
        //    };

        //    var sonic = new Movie()
        //    {
        //        Id = 4,
        //        Title = "Sonic the Hedgehog",
        //        InTheaters = false,
        //        ReleaseDate = new DateTime(2020, 02, 28)
        //    };
        //    var emma = new Movie()
        //    {
        //        Id = 5,
        //        Title = "Emma",
        //        InTheaters = false,
        //        ReleaseDate = new DateTime(2020, 02, 21)
        //    };
        //    var greed = new Movie()
        //    {
        //        Id = 6,
        //        Title = "Greed",
        //        InTheaters = false,
        //        ReleaseDate = new DateTime(2020, 02, 21)
        //    };

        //    modelBuilder.Entity<Movie>()
        //        .HasData(new List<Movie>
        //        {
        //            endgame, iw, sonic, emma, greed
        //        });

        //    modelBuilder.Entity<MoviesGenres>().HasData(
        //        new List<MoviesGenres>()
        //        {
        //            new MoviesGenres(){MovieId = endgame.Id, GenreId = drama.Id},
        //            new MoviesGenres(){MovieId = endgame.Id, GenreId = adventure.Id},
        //            new MoviesGenres(){MovieId = iw.Id, GenreId = drama.Id},
        //            new MoviesGenres(){MovieId = iw.Id, GenreId = adventure.Id},
        //            new MoviesGenres(){MovieId = sonic.Id, GenreId = adventure.Id},
        //            new MoviesGenres(){MovieId = emma.Id, GenreId = drama.Id},
        //            new MoviesGenres(){MovieId = emma.Id, GenreId = romance.Id},
        //            new MoviesGenres(){MovieId = greed.Id, GenreId = drama.Id},
        //            new MoviesGenres(){MovieId = greed.Id, GenreId = romance.Id},
        //        });

        //    modelBuilder.Entity<MoviesActors>().HasData(
        //        new List<MoviesActors>()
        //        {
        //            new MoviesActors(){MovieId = endgame.Id, PersonId = lenuta.Id, Character = "Tony Stark", Order = 1},
        //            new MoviesActors(){MovieId = endgame.Id, PersonId = igor.Id, Character = "Steve Rogers", Order = 2},
        //            new MoviesActors(){MovieId = iw.Id, PersonId = lenuta.Id, Character = "Tony Stark", Order = 1},
        //            new MoviesActors(){MovieId = iw.Id, PersonId = igor.Id, Character = "Steve Rogers", Order = 2},
        //            new MoviesActors(){MovieId = sonic.Id, PersonId = sergiu.Id, Character = "Dr. Ivo Robotnik", Order = 1}
        //        });
        //}
    //}


        public DbSet<Project> Project { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Payment> Payment { get; set; }
        public DbSet<Admin> Admin { get; set; }
        public DbSet<File> File { get; set; }
        public DbSet<FavoriteProjects> FavoriteProjects { get; set; }
    }


}
