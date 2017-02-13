using RememBeer.Models.Contracts;
using RememBeer.Models.Dtos;

namespace RememBeer.Models.Factories
{
    public interface IBeerRankFactory
    {
        IBeerRank CreateBeerRank(decimal overallScore,
                         decimal tasteScore,
                         decimal lookScore,
                         decimal smellScore,
                         IBeer beer,
                         decimal compositeScore,
                         int totalReviews);
    }
}
