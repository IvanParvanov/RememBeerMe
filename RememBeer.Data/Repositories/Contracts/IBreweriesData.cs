using System.Linq;

using RememBeer.Models;

namespace RememBeer.Data.Repositories.Contracts
{
    public interface IBreweriesData
    {
        IQueryable<Brewery> Breweries { get; }
    }
}