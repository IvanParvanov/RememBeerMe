using System.Linq;

using RememBeer.Models;

namespace RememBeer.Data.Repositories.Contracts
{
    public interface IBeerTypesData
    {
        IQueryable<BeerType> BeerTypes { get; }
    }
}