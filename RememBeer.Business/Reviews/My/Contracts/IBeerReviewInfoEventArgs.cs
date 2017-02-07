using RememBeer.Models;
using RememBeer.Models.Contracts;

namespace RememBeer.Business.Reviews.My.Contracts
{
    public interface IBeerReviewInfoEventArgs
    {
        BeerReview BeerReview { get; set; }
    }
}