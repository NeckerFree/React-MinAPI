using Microsoft.EntityFrameworkCore;

namespace reactminapi.dataAccess.Models
{
    public class RunningContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Training> Trainings { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlite(@"DataSource=C:\Temp\RunningDB.db");
        }
  
    }
}
