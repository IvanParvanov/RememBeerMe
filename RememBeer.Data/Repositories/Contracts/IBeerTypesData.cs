using RememBeer.Data.Repositories.Base;
using RememBeer.Models;

namespace RememBeer.Data.Repositories.Contracts
{
    public interface IBeerTypesData
    {
        IGenericRepository<BeerType> BeerTypes { get; set; }
    }
}