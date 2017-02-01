using RememBeer.Data.Repositories.Base;
using RememBeer.Models;

namespace RememBeer.Data.Repositories.Contracts
{
    public interface IBeerReviewsData
    {
        IGenericRepository<BeerReview> BeerReviews { get; set; }
    }
}