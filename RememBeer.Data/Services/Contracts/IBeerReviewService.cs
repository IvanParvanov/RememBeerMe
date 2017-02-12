using System.Collections.Generic;

using RememBeer.Models;
using RememBeer.Models.Contracts;

namespace RememBeer.Data.Services.Contracts
{
    public interface IBeerReviewService
    {
        IEnumerable<IBeerReview> GetReviewsForUser(string user);

        void UpdateReview(BeerReview review);

        void CreateReview(BeerReview review);

        void DeleteReview(object id);

        IBeerReview GetById(object id);
    }
}
