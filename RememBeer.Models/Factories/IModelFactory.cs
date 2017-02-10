using RememBeer.Common.Identity.Contracts;
using RememBeer.Models.Contracts;
using RememBeer.Models.Dtos;

namespace RememBeer.Models.Factories
{
    public interface IModelFactory
    {
        IApplicationUser CreateApplicationUser(string username, string email);

        IBeerRank CreateBeerRank(decimal overallScore,
                                 decimal tasteScore,
                                 decimal lookScore,
                                 decimal smellScore,
                                 IBeer beer,
                                 decimal compositeScore,
                                 int totalReviews);
    }
}
