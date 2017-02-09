using RememBeer.Models;

namespace RememBeer.Business.Reviews.My.Contracts
{
    public interface IBeerReviewInfoEventArgs
    {
        BeerReview BeerReview { get; set; }
    }
}