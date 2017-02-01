using System.Linq;

using RememBeer.Data.Repositories.Base;
using RememBeer.Models;

namespace RememBeer.Data.Repositories.Contracts
{
    public interface IBeersData
    {
        IQueryable<Beer> Beers { get; }
    }
}