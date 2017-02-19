using System;
using System.Collections.Generic;

using RememBeer.Business.Services.RankingStrategies.Contracts;
using RememBeer.Models.Contracts;
using RememBeer.Models.Dtos;
using RememBeer.Models.Factories;

namespace RememBeer.Business.Services.RankingStrategies.Base
{
    public abstract class RankCalculationStrategy : IRankCalculationStrategy
    {
        private readonly IRankFactory factory;

        protected RankCalculationStrategy(IRankFactory factory)
        {
            if (factory == null)
            {
                throw new ArgumentNullException(nameof(factory));
            }

            this.factory = factory;
        }

        protected IRankFactory Factory => this.factory;

        public abstract IBeerRank GetBeerRank(IEnumerable<IBeerReview> reviews, IBeer beer);

        public abstract IBreweryRank GetBreweryRank(IEnumerable<IBeerRank> beerRanks, string breweryName);
    }
}
