using System.Linq;

using RememBeer.Data.Repositories.Base;
using RememBeer.Models;

namespace RememBeer.Data.Repositories.Contracts
{
    public interface IBeerReviewsData
    {
        IQueryable<BeerReview> BeerReviews { get; }
    }
}