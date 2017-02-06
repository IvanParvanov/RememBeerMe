using System.Collections.Generic;
using System.Linq;

using RememBeer.Data.Repositories.Contracts;
using RememBeer.Models;
using RememBeer.Models.Contracts;
using RememBeer.Models.Factories;

namespace RememBeer.Data.Services
{
    public class BeerReviewService : IBeerReviewService
    {
        private readonly IModelFactory factory;
        private readonly IBeerReviewsData data;

        public BeerReviewService(IBeerReviewsData data, IModelFactory factory)
        {
            this.data = data;
            this.factory = factory;
        }

        public ICollection<BeerReview> GetReviewsForUser(string user)
        {
            return this.data.BeerReviews.Where(rv => rv.UserId == user)
                       .OrderBy(x => x.CreatedAt)
                       .ToList();
        }

        public void UpdateReview(IBeerReview review)
        {
            throw new System.NotImplementedException();
        }
    }

    public interface IBeerReviewService
    {
        ICollection<BeerReview> GetReviewsForUser(string user);

        void UpdateReview(IBeerReview review);
    }
}
