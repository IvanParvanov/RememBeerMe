using System.Collections.Generic;

using RememBeer.Data.Repositories;
using RememBeer.Models.Contracts;

namespace RememBeer.Business.Services.Contracts
{
    public interface IBeerReviewService
    {
        IEnumerable<IBeerReview> GetReviewsForUser(string user);

        IDataModifiedResult UpdateReview(IBeerReview review);

        IDataModifiedResult CreateReview(IBeerReview review);

        IDataModifiedResult DeleteReview(object id);

        IBeerReview GetById(object id);
    }
}
