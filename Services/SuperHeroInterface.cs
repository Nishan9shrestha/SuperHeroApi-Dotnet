using SuperHeroAPI.Models;

namespace SuperHeroAPI.Services
{
    public interface SuperHeroInterface
    {
        SuperHero GetSuperheroId(int id);
        List<SuperHero> GetSuperHeroes();
        List<SuperHero> EnterHero(SuperHero hero1);
        List<SuperHero> UpdateHero(int id, SuperHero value);
        List<SuperHero>DeleteHero(int id);

    }
}
