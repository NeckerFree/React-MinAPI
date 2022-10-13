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
            optionsBuilder.UseSqlite(@"DataSource=C:\Elio\DB\RunningDB.db");
        }
    //    protected override void OnModelCreating(ModelBuilder modelBuilder)
    //    {
    //        modelBuilder
    //            .Entity<Training>()
    //            .Property(e => e.Feel)
    //            .HasConversion(
    //                v => v.ToString(),
    //                v => (EnumFeel)Enum.Parse(typeof(EnumFeel), v));

    //        modelBuilder.Entity<Training>()
    //.Property(e => e.Date)
    //.HasConversion(
    //    v => v,
    //    v => new DateTime(v.Year, v.Month, v.Day).ToShortDateString();
    //    }
    }
}
