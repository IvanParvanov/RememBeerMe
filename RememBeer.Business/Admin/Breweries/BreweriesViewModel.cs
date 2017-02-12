using System.Collections.Generic;

using RememBeer.Models.Contracts;

namespace RememBeer.Business.Admin.Breweries
{
    public class BreweriesViewModel
    {
        public IEnumerable<IBrewery> Breweries { get; set; }
    }
}
