using APIRotasBeta.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace APIRotasBeta.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CachorroController : ControllerBase
    {
        List<Cachorro> dogs = new List<Cachorro>();

        public CachorroController()
        {
            Cachorro c = new Cachorro { Nome = "Xurupita", Idade = 18, Apelido="x"};
          
            dogs.Add(c);
        }
        
        [HttpGet]
        public List<Cachorro> GetDog()
        {
            return dogs;
        }
        [HttpGet("Nome/{n}", Name = "BuscaNome")]
        public Cachorro GetDogName(string n)
        {
            return dogs.Find(x => x.Nome == n);
        }

        [HttpPost("/{n}/{i}/{a}")]
        public ActionResult AdicionaDog(string n, int i, string a)
        {
            var dog = new Cachorro() { Nome = n, Idade = i, Apelido = a};
            dogs.Add(dog);
            return CreatedAtRoute("BuscaNome", dog.Nome);
        }
    }
}
