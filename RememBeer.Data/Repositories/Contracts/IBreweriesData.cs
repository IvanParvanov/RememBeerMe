using RememBeer.Data.Repositories.Base;
using RememBeer.Models;

namespace RememBeer.Data.Repositories.Contracts
{
    public interface IBreweriesData
    {
        IGenericRepository<Brewery> Breweries { get; set; }
    }
}