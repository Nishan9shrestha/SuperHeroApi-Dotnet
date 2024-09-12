using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperHeroAPI.Models;
using System.Runtime.CompilerServices;
using System.Security.Principal;
using SuperHeroAPI.Services;

namespace SuperHeroAPI.Controllers//press ctrl+k and ctrl+d to format the code
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private readonly SuperHeroInterface _superheroservices;


        public SuperHeroController(SuperHeroInterface superheroservices)//constructor
        {
            _superheroservices = superheroservices;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHero>> GetSuperheroId(int id)
        {
            var result = _superheroservices.GetSuperheroId(id);
            if (result is null)
                return NotFound("Sorry! No Such Super Hero Exists");

            return Ok(result);
        }


        [HttpGet] //this gives all of the records
        public async Task<ActionResult<List<SuperHero>>> GetSuperHeroes()//this ActionrResult<List<SuperHero>> gives the list like format befor trying out the endpoints
        {

            return _superheroservices.GetSuperHeroes();
        }


        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> EnterHero(SuperHero hero1)
        {
            var result = _superheroservices.EnterHero(hero1);
            return Ok(result);
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<List<SuperHero>>> UpdateHero(int id, SuperHero value)
        {
            var result = _superheroservices.UpdateHero(id, value);
            if (result is null)
                return NotFound("No such hero exists");

            return Ok(result);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<List<SuperHero>>> DeleteHero(int id)
        {
           var result = _superheroservices.DeleteHero(id);
            
            return Ok(result);
        }


    }
}
