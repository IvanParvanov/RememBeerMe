using System;
using System.Collections.Generic;
using System.Linq;

using RememBeer.Business.Services.Contracts;
using RememBeer.Business.Services.RankingStrategies.Contracts;
using RememBeer.Common.Cache.Attributes;
using RememBeer.Data.Repositories.Base;
using RememBeer.Models;
using RememBeer.Models.Dtos;

namespace RememBeer.Business.Services
{
    public class TopBeersService : ITopBeersService
    {
        private readonly IRepository<BeerReview> reviewsRepository;
        private readonly IBeerRankCalculationStrategy strategy;

        public TopBeersService(IRepository<BeerReview> reviewsRepository, IBeerRankCalculationStrategy strategy)
        {
            if (reviewsRepository == null)
            {
                throw new ArgumentNullException(nameof(reviewsRepository));
            }

            if (strategy == null)
            {
                throw new ArgumentNullException(nameof(strategy));
            }

            this.strategy = strategy;
            this.reviewsRepository = reviewsRepository;
        }

        [Cache(10)]
        public virtual IEnumerable<IBeerRank> GetTopBeers(int top = int.MaxValue)
        {
            var rankings = new List<IBeerRank>();

            var groupedReviews = this.reviewsRepository.All.Where(r => !r.IsDeleted).GroupBy(r => r.Beer);
            foreach (var grouping in groupedReviews)
            {
                var rank = this.strategy.GetRank(grouping, grouping.Key);
                rankings.Add(rank);
            }

            return rankings.OrderByDescending(r => r.CompositeScore)
                           .Take(top)
                           .ToList();
        }

        [Cache(20)]
        public virtual IEnumerable<IBreweryRank> GetTopBreweries(int top)
        {
            var allBeerRankings = this.GetTopBeers();
            var groupedByBrewery = allBeerRankings.GroupBy(b => b.Beer.Brewery.Name);

            var rankings = new List<IBreweryRank>();
            foreach (var breweryBeers in groupedByBrewery)
            {
                var totalCount = breweryBeers.Count();
                var totalScore = breweryBeers.Sum(s => (decimal)s.CompositeScore) / totalCount;
                var totalReviewCount = breweryBeers.Sum(b => b.Beer.Reviews.Count);
                var ranking = new BreweryRank()
                              {
                                  AveragePerBeer = totalScore,
                                  TotalBeersCount = totalReviewCount,
                                  Name = breweryBeers.Key
                              };
                rankings.Add(ranking);
            }

            return rankings.OrderByDescending(r => r.AveragePerBeer)
                           .Take(top);
        }
    }
}
