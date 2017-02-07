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
            return this.data.BeerReviews.GetAll(x => x.UserId == user, x => x.CreatedAt).ToList();
        }

        public void UpdateReview(BeerReview review)
        {
            this.data.BeerReviews.Update(review);
            this.data.BeerReviews.SaveChanges();
        }

        public void CreateReview(BeerReview review)
        {
            this.data.BeerReviews.Add(review);
            this.data.BeerReviews.SaveChanges();
        }
    }

    public interface IBeerReviewService
    {
        ICollection<BeerReview> GetReviewsForUser(string user);

        void UpdateReview(BeerReview review);

        void CreateReview(BeerReview review);
    }
}
