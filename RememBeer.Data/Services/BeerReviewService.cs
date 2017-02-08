using System.Collections.Generic;
using System.Linq;

using RememBeer.Data.Repositories.Base;
using RememBeer.Data.Repositories.Contracts;
using RememBeer.Models;
using RememBeer.Models.Contracts;
using RememBeer.Models.Factories;

namespace RememBeer.Data.Services
{
    public class BeerReviewService : IBeerReviewService
    {
        private readonly IModelFactory factory;
        private readonly IRepository<BeerReview> data;

        public BeerReviewService(IRepository<BeerReview> data, IModelFactory factory)
        {
            this.data = data;
            this.factory = factory;
        }

        public ICollection<BeerReview> GetReviewsForUser(string user)
        {
            return this.data.GetAll(x => x.UserId == user, x => x.CreatedAt).ToList();
        }

        public void UpdateReview(BeerReview review)
        {
            this.data.Update(review);
            this.data.SaveChanges();
        }

        public void CreateReview(BeerReview review)
        {
            this.data.Add(review);
            this.data.SaveChanges();
        }
    }

    public interface IBeerReviewService
    {
        ICollection<BeerReview> GetReviewsForUser(string user);

        void UpdateReview(BeerReview review);

        void CreateReview(BeerReview review);
    }
}
