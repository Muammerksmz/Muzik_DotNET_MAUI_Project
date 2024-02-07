using Microsoft.EntityFrameworkCore;

namespace Muzik.Models
{
    public class AppDbContext : DbContext
    {
        private const string DatabaseName = "Songs.db";

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Song>().ToTable("Songs");
            // Diğer tabloları burada tanımlayabilirsiniz...
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DatabaseName);
            optionsBuilder.UseSqlite($"Filename={databasePath}");
        }

        // DbSet'lerinizi tanımlayabilirsiniz
        public DbSet<Song> Songs { get; set; }

        public AppDbContext()
        {
            this.Database.EnsureCreated();
        }
    }
}