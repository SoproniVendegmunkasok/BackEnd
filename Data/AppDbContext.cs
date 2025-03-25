using System.Reflection.Emit;
using GuestHibajelentesEvvegi.Models;
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

            //Seed Data

            builder.Entity<User>().HasData(
                new User { UserName = "user1", NormalizedUserName = "USER1", Email = "user1@example.com", NormalizedEmail = "USER1@EXAMPLE.COM", EmailConfirmed = true, PasswordHash = "AQAAAAEAACcQAAAAE1234567ABCDEFGHIJKLMNOPQRSTUVWXYZ", SecurityStamp = "ABC123", ConcurrencyStamp = "XYZ123" },
                new User { UserName = "user2", NormalizedUserName = "USER2", Email = "user2@example.com", NormalizedEmail = "USER2@EXAMPLE.COM", EmailConfirmed = true, PasswordHash = "AQAAAAEAACcQAAAAE2345678ABCDEFGHIJKLMNOPQRSTUVWXYZ", SecurityStamp = "DEF456", ConcurrencyStamp = "UVW456" },
                new User { UserName = "user3", NormalizedUserName = "USER3", Email = "user3@example.com", NormalizedEmail = "USER3@EXAMPLE.COM", EmailConfirmed = true, PasswordHash = "AQAAAAEAACcQAAAAE3456789ABCDEFGHIJKLMNOPQRSTUVWXYZ", SecurityStamp = "GHI789", ConcurrencyStamp = "RST789" },
                new User { UserName = "user4", NormalizedUserName = "USER4", Email = "user4@example.com", NormalizedEmail = "USER4@EXAMPLE.COM", EmailConfirmed = true, PasswordHash = "AQAAAAEAACcQAAAAE4567890ABCDEFGHIJKLMNOPQRSTUVWXYZ", SecurityStamp = "JKL012", ConcurrencyStamp = "OPQ012" }
                // Add more users here as needed
            );

            builder.Entity<Machine>().HasData(
                new Machine { name = "Machine1", status = Status_machine.funkcionalis, hall = "H1", created_at = DateTime.Now },
                new Machine { name = "Machine2", status = Status_machine.hibas, hall = "H2", created_at = DateTime.Now },
                new Machine { name = "Machine3", status = Status_machine.funkcionalis, hall = "H3", created_at = DateTime.Now },
                new Machine { name = "Machine4", status = Status_machine.hibas, hall = "H4", created_at = DateTime.Now }
                // Add more machines here as needed
            );

            builder.Entity<Error>().HasData(
                new Error { status = Status_error.uj, description = "Error description 1", submitted_by = "user1", machine_id = 1, assigned_to = "user2", created_at = DateTime.Now, resolved_at = DateTime.Now.AddDays(1) },
                new Error { status = Status_error.javitas_alatt, description = "Error description 2", submitted_by = "user2", machine_id = 2, assigned_to = "user3", created_at = DateTime.Now, resolved_at = DateTime.Now.AddDays(2) },
                new Error { status = Status_error.elvegzett, description = "Error description 3", submitted_by = "user3", machine_id = 3, assigned_to = "user4", created_at = DateTime.Now, resolved_at = DateTime.Now.AddDays(3) },
                new Error { status = Status_error.uj, description = "Error description 4", submitted_by = "user4", machine_id = 4, assigned_to = "user1", created_at = DateTime.Now, resolved_at = DateTime.Now.AddDays(4) }
                // Add more errors here as needed
            );

            builder.Entity<ErrorTask>().HasData(
                // Tasks for Error 1
                new ErrorTask { description = "Task 1 for Error 1", assigned_to = "user2", error_id = 1, created_at = DateTime.Now, resolved_at = DateTime.Now.AddHours(1) },
                new ErrorTask { description = "Task 2 for Error 1", assigned_to = "user2", error_id = 1, created_at = DateTime.Now, resolved_at = DateTime.Now.AddHours(2) },
                new ErrorTask { description = "Task 3 for Error 1", assigned_to = "user2", error_id = 1, created_at = DateTime.Now, resolved_at = DateTime.Now.AddHours(3) },

                // Tasks for Error 2
                new ErrorTask { description = "Task 1 for Error 2", assigned_to = "user3", error_id = 2, created_at = DateTime.Now, resolved_at = DateTime.Now.AddHours(1) },
                new ErrorTask { description = "Task 2 for Error 2", assigned_to = "user3", error_id = 2, created_at = DateTime.Now, resolved_at = DateTime.Now.AddHours(2) },
                new ErrorTask { description = "Task 3 for Error 2", assigned_to = "user3", error_id = 2, created_at = DateTime.Now, resolved_at = DateTime.Now.AddHours(3) },

                // Tasks for Error 3
                new ErrorTask { description = "Task 1 for Error 3", assigned_to = "user4", error_id = 3, created_at = DateTime.Now, resolved_at = DateTime.Now.AddHours(1) },
                new ErrorTask { description = "Task 2 for Error 3", assigned_to = "user4", error_id = 3, created_at = DateTime.Now, resolved_at = DateTime.Now.AddHours(2) },
                new ErrorTask { description = "Task 3 for Error 3", assigned_to = "user4", error_id = 3, created_at = DateTime.Now, resolved_at = DateTime.Now.AddHours(3) },

                // Tasks for Error 4
                new ErrorTask { description = "Task 1 for Error 4", assigned_to = "user1", error_id = 4, created_at = DateTime.Now, resolved_at = DateTime.Now.AddHours(1) },
                new ErrorTask { description = "Task 2 for Error 4", assigned_to = "user1", error_id = 4, created_at = DateTime.Now, resolved_at = DateTime.Now.AddHours(2) },
                new ErrorTask { description = "Task 3 for Error 4", assigned_to = "user1", error_id = 4, created_at = DateTime.Now, resolved_at = DateTime.Now.AddHours(3) }
                // Add more tasks here as needed
            );
        }
    }
}
