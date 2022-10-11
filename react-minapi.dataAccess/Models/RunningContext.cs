using Microsoft.EntityFrameworkCore;

namespace react_minapi.dataAccess.Models
{
    public class RunningContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlite(@"DataSource=C:\Elio\DB\RunningDB.db");
        }
    }
}
