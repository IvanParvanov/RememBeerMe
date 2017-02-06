using System.Collections.Generic;

namespace RememBeer.Models.Contracts
{
    public interface IBrewery
    {
        string Name { get; set; }

        string Description { get; set; }

        string Country { get; set; }

        ICollection<Beer> Beers { get; set; }
    }
}