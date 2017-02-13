using RememBeer.Models.Contracts;

namespace RememBeer.Business.Reviews.My.Contracts
{
    public interface IBeerReviewInfoEventArgs
    {
        IBeerReview BeerReview { get; set; }

        byte[] Image { get; set; }
    }
}