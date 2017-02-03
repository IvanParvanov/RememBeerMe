using System.Linq;

using RememBeer.Models;

namespace RememBeer.Data.Repositories.Contracts
{
    public interface IBeerReviewsData
    {
        IQueryable<BeerReview> BeerReviews { get; }
    }
}