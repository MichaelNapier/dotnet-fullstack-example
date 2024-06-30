using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using BackendApi.Models;

namespace BackendApi.Database
{
    public class ApplicationDbContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public ApplicationDbContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to postgres with connection string from appsettings 
            options.UseNpgsql(Configuration.GetConnectionString("Database"));
        }

        public DbSet<Player> Player { get; set; }
        public DbSet<Game> Game { get; set; }
        public DbSet<Flags> Flags { get; set; }
        
    }
}