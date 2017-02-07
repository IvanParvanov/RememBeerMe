using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

using RememBeer.Data.DbContexts;
using RememBeer.Data.Repositories.Base;
using RememBeer.Models;

namespace RememBeer.WebClient.Api
{
    public class BeersController : ApiController
    {
        private readonly IRepository<Beer> beers;

        //TODO: DI!
        public BeersController()
        {
            var db = new RememBeerMeDbContext();
            this.beers = new Repository<Beer>(db);
        }

        public BeersController(IRepository<Beer> beers)
        {
            this.beers = beers;
        }

        // GET api/<controller>
        public IEnumerable<BeerDto> Get()
        {
            return this.beers.GetAll()
                       .Select(b => new BeerDto()
                                    {
                                        Id = b.Id,
                                        Name = b.Name,
                                        BreweryId = b.Brewery.Id,
                                        BreweryName = b.Brewery.Name
                                    });
        }

        public IEnumerable<BeerDto> Get(string name)
        {
            return this.beers
                       .GetAll((beer) => beer.Name.StartsWith(name), beer => beer.Name)
                       .Select(b => new BeerDto()
                                    {
                                        Id = b.Id,
                                        Name = b.Name,
                                        BreweryId = b.Brewery.Id,
                                        BreweryName = b.Brewery.Name
                                    });
        }

        // GET api/<controller>/5
        public Beer Get(int id)
        {
            return this.beers.GetById(id);
        }
    }

    public class BeerDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int BreweryId { get; set; }

        public string BreweryName { get; set; }
    }
}
