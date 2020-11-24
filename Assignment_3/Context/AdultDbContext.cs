using Microsoft.EntityFrameworkCore;
using Models;

namespace Assignment_3.Context
{
    public class AdultDbContext : DbContext
    {
        public DbSet<Adult> Adults { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source = C:\University\DNP\Assignment_2\Assignment_3\AdultsDatabase.db");
        }
    }
}