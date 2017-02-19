using System;

using Moq;

using NUnit.Framework;

using RememBeer.Business.Services;
using RememBeer.Business.Services.RankingStrategies.Contracts;
using RememBeer.Data.Repositories.Base;
using RememBeer.Models;

namespace RememBeer.Tests.Business.Services.TopBeerServiceTests
{
    [TestFixture]
    public class Ctor_Should
    {
        [Test]
        public void ThrowArgumentNullException_WhenRepositoryIsNull()
        {
            var strategy = new Mock<IRankCalculationStrategy>();
            Assert.Throws<ArgumentNullException>(() => new TopBeersService(null, strategy.Object));
        }

        [Test]
        public void ThrowArgumentNullException_WhenStrategyIsNull()
        {
            var repo = new Mock<IRepository<BeerReview>>();
            Assert.Throws<ArgumentNullException>(() => new TopBeersService(repo.Object, null));
        }
    }
}
