using System.Collections.Generic;

using RememBeer.Models.Contracts;
using RememBeer.Models.Dtos;

namespace RememBeer.Business.Services.RankingStrategies.Contracts
{
    public interface IBeerRankCalculationStrategy
    {
        IBeerRank GetRank(IEnumerable<IBeerReview> reviews, IBeer beer);
    }
}
