using System.Reflection.Emit;
using GuestHibajelentesEvvegi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GuestHibajelentesEvvegi.Data
{
    public class AppDbContext : IdentityDbContext<User>
    {
        public DbSet<User> Users { get; set; }
        public DbSet<ErrorTask> Tasks { get; set; }
        public DbSet<Machine> Machines { get; set; }
        public DbSet<Error> Errors { get; set; }
        public DbSet<ErrorLog> Error_logs { get; set; }

        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Seed Data

            var passwordHasher = new PasswordHasher<User>();

            // Seed Data
            var plainTextPassword1 = "Password123";
            var plainTextPassword2 = "Password234";
            var plainTextPassword3 = "Password345";
            var plainTextPassword4 = "Password456";
            builder.Entity<User>().HasData(
                new User { Id = "1", UserName = "user1", NormalizedUserName = "USER1", Email = "user1@example.com", NormalizedEmail = "USER1@EXAMPLE.COM", EmailConfirmed = true, PasswordHash = passwordHasher.HashPassword(null, plainTextPassword1), SecurityStamp = "ABC123", ConcurrencyStamp = "XYZ123" },
                new User { Id = "2", UserName = "user2", NormalizedUserName = "USER2", Email = "user2@example.com", NormalizedEmail = "USER2@EXAMPLE.COM", EmailConfirmed = true, PasswordHash = passwordHasher.HashPassword(null, plainTextPassword2), SecurityStamp = "DEF456", ConcurrencyStamp = "UVW456" },
                new User { Id = "3", UserName = "user3", NormalizedUserName = "USER3", Email = "user3@example.com", NormalizedEmail = "USER3@EXAMPLE.COM", EmailConfirmed = true, PasswordHash = passwordHasher.HashPassword(null, plainTextPassword3), SecurityStamp = "GHI789", ConcurrencyStamp = "RST789" },
                new User { Id = "4", UserName = "user4", NormalizedUserName = "USER4", Email = "user4@example.com", NormalizedEmail = "USER4@EXAMPLE.COM", EmailConfirmed = true, PasswordHash = passwordHasher.HashPassword(null, plainTextPassword4), SecurityStamp = "JKL012", ConcurrencyStamp = "OPQ012" }
            // Add more users here as needed
            );

            builder.Entity<Machine>().HasData(
                new Machine { Id = 1, name = "Machine1", status = Status_machine.funkcionalis, hall = "H1", created_at = DateTime.Now },
                new Machine { Id = 2, name = "Machine2", status = Status_machine.hibas, hall = "H2", created_at = DateTime.Now },
                new Machine { Id = 3, name = "Machine3", status = Status_machine.funkcionalis, hall = "H3", created_at = DateTime.Now },
                new Machine { Id = 4, name = "Machine4", status = Status_machine.hibas, hall = "H4", created_at = DateTime.Now }
            // Add more machines here as needed
            );

            builder.Entity<Error>().HasData(
                new Error { Id = 1, status = Status_error.uj, description = "Error description 1", submitted_by = "1", machine_id = 1, assigned_to = "2", created_at = DateTime.Now, resolved_at = DateTime.Now.AddDays(1) },
                new Error { Id = 2, status = Status_error.javitas_alatt, description = "Error description 2", submitted_by = "2", machine_id = 2, assigned_to = "3", created_at = DateTime.Now, resolved_at = DateTime.Now.AddDays(2) },
                new Error { Id = 3, status = Status_error.elvegzett, description = "Error description 3", submitted_by = "3", machine_id = 3, assigned_to = "4", created_at = DateTime.Now, resolved_at = DateTime.Now.AddDays(3) },
                new Error { Id = 4, status = Status_error.uj, description = "Error description 4", submitted_by = "4", machine_id = 4, assigned_to = "1", created_at = DateTime.Now, resolved_at = DateTime.Now.AddDays(4) }
            // Add more errors here as needed
            );

            builder.Entity<ErrorTask>().HasData(
                // Tasks for Error 1
                new ErrorTask { Id = 1, description = "Task 1 for Error 1", assigned_to = "2", error_id = 1, created_at = DateTime.Now, resolved_at = DateTime.Now.AddHours(1) },
                new ErrorTask { Id = 2, description = "Task 2 for Error 1", assigned_to = "2", error_id = 1, created_at = DateTime.Now, resolved_at = DateTime.Now.AddHours(2) },
                new ErrorTask { Id = 3, description = "Task 3 for Error 1", assigned_to = "2", error_id = 1, created_at = DateTime.Now, resolved_at = DateTime.Now.AddHours(3) },

                // Tasks for Error 2
                new ErrorTask { Id = 4, description = "Task 1 for Error 2", assigned_to = "3", error_id = 2, created_at = DateTime.Now, resolved_at = DateTime.Now.AddHours(1) },
                new ErrorTask { Id = 5, description = "Task 2 for Error 2", assigned_to = "3", error_id = 2, created_at = DateTime.Now, resolved_at = DateTime.Now.AddHours(2) },
                new ErrorTask { Id = 6, description = "Task 3 for Error 2", assigned_to = "3", error_id = 2, created_at = DateTime.Now, resolved_at = DateTime.Now.AddHours(3) },

                // Tasks for Error 3
                new ErrorTask { Id = 7, description = "Task 1 for Error 3", assigned_to = "4", error_id = 3, created_at = DateTime.Now, resolved_at = DateTime.Now.AddHours(1) },
                new ErrorTask { Id = 8, description = "Task 2 for Error 3", assigned_to = "4", error_id = 3, created_at = DateTime.Now, resolved_at = DateTime.Now.AddHours(2) },
                new ErrorTask { Id = 9, description = "Task 3 for Error 3", assigned_to = "4", error_id =3, created_at = DateTime.Now, resolved_at = DateTime.Now.AddHours(3) },

                // Tasks for Error 4
                new ErrorTask { Id = 10, description = "Task 1 for Error 4", assigned_to = "1", error_id = 4, created_at = DateTime.Now, resolved_at = DateTime.Now.AddHours(1) },
                new ErrorTask { Id = 11, description = "Task 2 for Error 4", assigned_to = "1", error_id = 4, created_at = DateTime.Now, resolved_at = DateTime.Now.AddHours(2) },
                new ErrorTask { Id = 12, description = "Task 3 for Error 4", assigned_to = "1", error_id = 4, created_at = DateTime.Now, resolved_at = DateTime.Now.AddHours(3) }
            );

        }
    }
}
