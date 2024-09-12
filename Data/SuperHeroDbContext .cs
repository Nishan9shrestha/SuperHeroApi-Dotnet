using Microsoft.EntityFrameworkCore;
using SuperHeroAPI.Models; // Adjust the namespace based on your project

namespace SuperHeroAPI.Data
{
    public class SuperHeroDbContext : DbContext
    {
        public SuperHeroDbContext(DbContextOptions<SuperHeroDbContext> options) : base(options)
        {
        }

        // Define DbSet for each entity you want to interact with and entity means models
        public DbSet<SuperHero> SuperHeroes { get; set; }
    }
}
