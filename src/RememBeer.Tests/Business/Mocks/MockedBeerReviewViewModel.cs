using RememBeer.Business.Logic.Reviews.Common.ViewModels;
using RememBeer.Models.Contracts;

namespace RememBeer.Tests.Business.Mocks
{
    public class MockedBeerReviewViewModel : BeerReviewViewModel
    {
        public override IBeerReview Review { get; set; }
    }
}
