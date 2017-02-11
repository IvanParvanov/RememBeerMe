using System.Collections.Generic;

using RememBeer.Models.Contracts;
using RememBeer.Models.Dtos;

namespace RememBeer.Data.Services.RankingStrategies
{
    public interface IBeerRankCalculationStrategy
    {
        IBeerRank GetRank(IEnumerable<IBeerReview> reviews, IBeer beer);
    }
}