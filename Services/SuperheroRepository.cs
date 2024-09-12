using SuperHeroAPI.Models;
using Microsoft.EntityFrameworkCore;
using SuperHeroAPI.Data;

namespace SuperHeroAPI.Services
{
    public class SuperheroRepository : SuperHeroInterface
    {
        private readonly SuperHeroDbContext _dbContext;

        public SuperheroRepository(SuperHeroDbContext dbContext) // Constructor injecting the context
        {
            _dbContext = dbContext;
        }

        // Add new hero to the database
        public List<SuperHero> EnterHero(SuperHero hero1)
        {
            _dbContext.SuperHeroes.Add(hero1); // Add the hero to the DbSet
            _dbContext.SaveChanges(); // Save changes to the database
            return _dbContext.SuperHeroes.ToList(); // Return the updated list of heroes
        }

        // Get all heroes from the database
        public List<SuperHero> GetSuperHeroes()
        {
            return _dbContext.SuperHeroes.ToList(); // Return all heroes from the DbSet
        }

        // Get a specific hero by ID
        public SuperHero GetSuperheroId(int id)
        {
            var ind_H = _dbContext.SuperHeroes.Find(id); // Find the hero by ID in the DbSet
            return ind_H; // Return the found hero or null
        }

        // Update a hero's information in the database
        public List<SuperHero> UpdateHero(int id, SuperHero value)
        {
            var hId = _dbContext.SuperHeroes.Find(id); // Find the hero by ID
            if (hId is null)
                return null;

            hId.Name = value.Name;
            hId.FirstName = value.FirstName;
            hId.LastName = value.LastName;
            hId.Place = value.Place;

            _dbContext.SaveChanges(); // Save changes to the database

            return _dbContext.SuperHeroes.ToList(); // Return the updated list of heroes
        }

        // Delete a hero by ID from the database
        public List<SuperHero> DeleteHero(int id)
        {
            var Gid = _dbContext.SuperHeroes.Find(id); // Find the hero by ID
            if (Gid is null)
                return null;

            _dbContext.SuperHeroes.Remove(Gid); // Remove the hero from the DbSet
            _dbContext.SaveChanges(); // Save changes to the database

            return _dbContext.SuperHeroes.ToList(); // Return the updated list of heroes
        }
    }
}
