using System.Collections.Generic;
using System.Linq;

using RememBeer.Data.Repositories.Base;
using RememBeer.Data.Services.Contracts;
using RememBeer.Models;
using RememBeer.Models.Contracts;

namespace RememBeer.Data.Services
{
    public class BeerReviewService : IBeerReviewService
    {
        private readonly IRepository<BeerReview> repository;

        public BeerReviewService(IRepository<BeerReview> repository)
        {
            this.repository = repository;
        }

        public IEnumerable<IBeerReview> GetReviewsForUser(string user)
        {
            return this.repository.GetAll(x => x.IsDeleted == false && x.UserId == user, x => x.CreatedAt).ToList();
        }

        public void UpdateReview(IBeerReview review)
        {
            var rv = review as BeerReview;
            this.repository.Update(rv);
            this.repository.SaveChanges();
        }

        public void CreateReview(IBeerReview review)
        {
            var rv = review as BeerReview;
            this.repository.Add(rv);
            this.repository.SaveChanges();
        }

        public void DeleteReview(object id)
        {
            var review = this.repository.GetById(id);
            review.IsDeleted = true;
            this.repository.SaveChanges();
        }

        public IBeerReview GetById(object id)
        {
            return this.repository.GetById(id);
        }
         
    }
}