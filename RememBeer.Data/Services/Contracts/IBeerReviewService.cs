using System.Collections.Generic;

using RememBeer.Models.Contracts;

namespace RememBeer.Data.Services.Contracts
{
    public interface IBeerReviewService
    {
        IEnumerable<IBeerReview> GetReviewsForUser(string user);

        void UpdateReview(IBeerReview review);

        void CreateReview(IBeerReview review);

        void DeleteReview(object id);

        IBeerReview GetById(object id);
    }
}
