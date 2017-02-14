using System.Collections.Generic;

using RememBeer.Models.Dtos;

namespace RememBeer.Business.Services.Contracts
{
    public interface ITopBeersService
    {
        IEnumerable<IBeerRank> GetTopBeers(int top);
    }
}
