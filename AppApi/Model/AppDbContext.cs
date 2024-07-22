using Microsoft.EntityFrameworkCore;

namespace AppApi.Model
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=ADMIN-PC\\SQLEXPRESS;Database=ProfileDatabase_2;Trusted_Connection=True;TrustServerCertificate=True");
        }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Categories> Categories { get; set; }
        public DbSet<Video> Videos { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<BackGround> BackGrounds { get; set; }
        public DbSet<About> Abouts { get; set; }
    }
    
}
