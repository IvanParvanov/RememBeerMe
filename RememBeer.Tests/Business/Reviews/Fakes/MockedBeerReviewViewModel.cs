using RememBeer.Business.Reviews.Common.ViewModels;
using RememBeer.Models.Contracts;

namespace RememBeer.Tests.Business.Reviews.Fakes
{
    public class MockedBeerReviewViewModel : BeerReviewViewModel
    {
        public override IBeerReview Review { get; set; }
    }
}
