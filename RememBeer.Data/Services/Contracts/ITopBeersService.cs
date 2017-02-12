using System.Collections.Generic;

using RememBeer.Models.Dtos;

namespace RememBeer.Data.Services.Contracts
{
    public interface ITopBeersService
    {
        IEnumerable<IBeerRank> GetTopBeers(int top);
    }
}