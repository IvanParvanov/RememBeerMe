using System;
using System.Collections.Generic;
using System.Linq;

using RememBeer.Data.Repositories.Base;
using RememBeer.Data.Services.Contracts;
using RememBeer.Models;
using RememBeer.Models.Dtos;
using RememBeer.Models.Factories;

namespace RememBeer.Data.Services
{
    public class TopBeersService : ITopBeersService
    {
        private readonly IRepository<BeerReview> reviewsRepository;
        private readonly IModelFactory factory;

        public TopBeersService(IRepository<BeerReview> reviewsRepository,
                               IModelFactory factory)
        {
            if (reviewsRepository == null)
            {
                throw new ArgumentNullException(nameof(reviewsRepository));
            }

            if (factory == null)
            {
                throw new ArgumentNullException(nameof(factory));
            }

            this.factory = factory;
            this.reviewsRepository = reviewsRepository;
        }

        public ICollection<IBeerRank> GetTopBeers(int top)
        {
            var rankings = new List<IBeerRank>();

            var groupedReviews = this.reviewsRepository.All.Where(r => !r.IsDeleted).GroupBy(r => r.Beer);
            foreach (var grouping in groupedReviews)
            {
                var reviewsCount = grouping.Count();

                decimal aggregateScore = grouping
                    .Sum(beerReview => (decimal)
                                       (2 * beerReview.Overall + beerReview.Look + beerReview.Smell + beerReview.Taste)
                                       / 5);
                var overallAverage = (decimal)grouping.Sum(r => r.Overall) / reviewsCount;
                var tasteAverage = (decimal)grouping.Sum(r => r.Taste) / reviewsCount;
                var smellAverage = (decimal)grouping.Sum(r => r.Smell) / reviewsCount;
                var lookverage = (decimal)grouping.Sum(r => r.Look) / reviewsCount;

                var finalScore = aggregateScore / reviewsCount;
                var rank = this.factory.CreateBeerRank(overallAverage,
                                                       tasteAverage,
                                                       lookverage,
                                                       smellAverage,
                                                       grouping.Key,
                                                       finalScore,
                                                       reviewsCount);

                rankings.Add(rank);
            }

            return rankings.OrderByDescending(r => r.CompositeScore)
                           .Take(top)
                           .ToList();
        }
    }
}
