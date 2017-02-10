using System.Collections.Generic;

using RememBeer.Models.Dtos;

namespace RememBeer.Data.Services.Contracts
{
    public interface ITopBeersService
    {
        ICollection<IBeerRank> GetTopBeers(int top);
    }
}