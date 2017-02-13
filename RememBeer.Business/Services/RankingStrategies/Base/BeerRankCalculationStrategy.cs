using System;
using System.Collections.Generic;

using RememBeer.Business.Services.RankingStrategies.Contracts;
using RememBeer.Models.Contracts;
using RememBeer.Models.Dtos;
using RememBeer.Models.Factories;

namespace RememBeer.Business.Services.RankingStrategies.Base
{
    public abstract class BeerRankCalculationStrategy : IBeerRankCalculationStrategy
    {
        private readonly IBeerRankFactory factory;

        protected BeerRankCalculationStrategy(IBeerRankFactory factory)
        {
            if (factory == null)
            {
                throw new ArgumentNullException(nameof(factory));
            }

            this.factory = factory;
        }

        protected IBeerRankFactory Factory => this.factory;

        public abstract IBeerRank GetRank(IEnumerable<IBeerReview> reviews, IBeer beer);
    }
}
