using System.Collections.Generic;
using System.Linq;

using RememBeer.Business.Services.Contracts;
using RememBeer.Data.Repositories;
using RememBeer.Data.Repositories.Base;
using RememBeer.Data.Repositories.Enums;
using RememBeer.Models;
using RememBeer.Models.Contracts;

namespace RememBeer.Business.Services
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
            return this.repository.GetAll(x => x.IsDeleted == false && x.UserId == user,
                                          x => x.CreatedAt,
                                          SortOrder.Descending)
                       .ToList();
        }

        public IDataModifiedResult UpdateReview(IBeerReview review)
        {
            var rv = review as BeerReview;
            this.repository.Update(rv);
            return this.repository.SaveChanges();
        }

        public IDataModifiedResult CreateReview(IBeerReview review)
        {
            var rv = review as BeerReview;
            this.repository.Add(rv);
            return this.repository.SaveChanges();
        }

        public IDataModifiedResult DeleteReview(object id)
        {
            var review = this.repository.GetById(id);
            review.IsDeleted = true;
            return this.repository.SaveChanges();
        }

        public IBeerReview GetById(object id)
        {
            return this.repository.GetById(id);
        }
    }
}
