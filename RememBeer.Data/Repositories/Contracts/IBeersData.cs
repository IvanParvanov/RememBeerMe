using RememBeer.Data.Repositories.Base;
using RememBeer.Models;

namespace RememBeer.Data.Repositories.Contracts
{
    public interface IBeersData
    {
        IGenericRepository<Beer> Beers { get; set; }
    }
}