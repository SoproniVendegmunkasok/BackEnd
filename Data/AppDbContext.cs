using GuestHibajelentesEvvegi.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GuestHibajelentesEvvegi.Data
{
    public class AppDbContext : IdentityDbContext<User>
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Error_task> Tasks { get; set; }
        public DbSet<Machine> Machines { get; set; }
        public DbSet<Error> Errors { get; set; }
        public DbSet<Error_log> Error_logs { get; set; }

        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
