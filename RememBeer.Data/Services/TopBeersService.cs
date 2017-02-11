using System;
using System.Collections.Generic;
using System.Linq;

using RememBeer.Data.Repositories.Base;
using RememBeer.Data.Services.Contracts;
using RememBeer.Data.Services.RankingStrategies;
using RememBeer.Models;
using RememBeer.Models.Dtos;

namespace RememBeer.Data.Services
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

        public ICollection<IBeerRank> GetTopBeers(int top)
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
    }
}
