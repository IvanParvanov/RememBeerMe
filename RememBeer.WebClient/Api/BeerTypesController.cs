using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

using RememBeer.Data.Repositories.Base;
using RememBeer.Data.Repositories.Enums;
using RememBeer.Models;
using RememBeer.Models.Dtos;

namespace RememBeer.WebClient.Api
{
    public class BeerTypesController : ApiController
    {
        private readonly IRepository<BeerType> beerTypes;

        public BeerTypesController(IRepository<BeerType> beerTypes)
        {
            this.beerTypes = beerTypes;
        }

        // GET api/BeerTypes?type={type}
        public IEnumerable<BeerTypeDto> Get(string type)
        {
            return this.beerTypes.GetAll(t => t.Type.Contains(type),
                                         t => t.Type,
                                         SortOrder.Ascending,
                                         b => new BeerTypeDto()
                                              {
                                                  Id = b.Id,
                                                  Type = b.Type
                                              });
        }
    }
}