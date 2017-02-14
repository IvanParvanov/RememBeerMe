using System.Collections.Generic;
using System.Linq;

using Moq;

using NUnit.Framework;

using Ploeh.AutoFixture;

using RememBeer.Business.Services;
using RememBeer.Business.Services.RankingStrategies.Contracts;
using RememBeer.Data.Repositories.Base;
using RememBeer.Models;
using RememBeer.Models.Dtos;
using RememBeer.Tests.Common;

namespace RememBeer.Tests.Business.Services.TopBeerServiceTests
{
    [TestFixture]
    public class GetTopBeers_Should : TestClassBase
    {
        [OneTimeSetUp]
        public void Init()
        {
            this.Fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList()
                .ForEach(b => this.Fixture.Behaviors.Remove(b));
            this.Fixture.Behaviors.Add(new OmitOnRecursionBehavior());
        }

        [Test]
        public void CallGetRankForEachReviewGroupWithSameBeer()
        {
            var totalReviews = 15;
            var reviews = new List<BeerReview>();
            var strategy = new Mock<IBeerRankCalculationStrategy>();
            for (var i = 0; i < totalReviews; i++)
            {
                var rv = this.Fixture.Create<BeerReview>();
                reviews.Add(rv);
            }

            var expectedGroups = reviews.Where(r => !r.IsDeleted).GroupBy(r => r.Beer);
            var enumerable = expectedGroups as IGrouping<Beer, BeerReview>[] ?? expectedGroups.ToArray();
            for (var i = 0; i < enumerable.Count(); i++)
            {
                var rank = new Mock<IBeerRank>();
                rank.SetupGet(r => r.CompositeScore)
                    .Returns(i);
                strategy.Setup(s => s.GetRank(enumerable[i], enumerable[i].Key))
                        .Returns(rank.Object);
            }

            var repository = new Mock<IRepository<BeerReview>>();
            repository.SetupGet(r => r.All)
                      .Returns(reviews.AsQueryable());

            var topBeersService = new TopBeersService(repository.Object, strategy.Object);

            topBeersService.GetTopBeers(10);

            foreach (var expectedGroup in enumerable)
            {
                strategy.Verify(s => s.GetRank(expectedGroup, expectedGroup.Key), Times.Once);
            }
        }

        [TestCase(15, 10)]
        [TestCase(10, 10)]
        [TestCase(8, 10)]
        public void ReturnCorrectNumberOfRanks(int totalReviews, int expectedCount)
        {
            var reviews = new List<BeerReview>();
            var strategy = new Mock<IBeerRankCalculationStrategy>();
            for (var i = 0; i < totalReviews; i++)
            {
                var rv = this.Fixture.Create<BeerReview>();
                reviews.Add(rv);
            }

            var expectedGroups = reviews.Where(r => !r.IsDeleted).GroupBy(r => r.Beer);
            var enumerable = expectedGroups as IGrouping<Beer, BeerReview>[] ?? expectedGroups.ToArray();
            for (var i = 0; i < enumerable.Length; i++)
            {
                var rank = new Mock<IBeerRank>();
                rank.SetupGet(r => r.CompositeScore)
                    .Returns(i);
                strategy.Setup(s => s.GetRank(enumerable[i], enumerable[i].Key))
                        .Returns(rank.Object);
            }

            var repository = new Mock<IRepository<BeerReview>>();
            repository.SetupGet(r => r.All)
                      .Returns(reviews.AsQueryable());

            var topBeersService = new TopBeersService(repository.Object, strategy.Object);

            var result = topBeersService.GetTopBeers(expectedCount);

            Assert.GreaterOrEqual(expectedCount, result.Count());
        }

        [TestCase(15, 10)]
        [TestCase(10, 10)]
        [TestCase(8, 10)]
        public void ReturnRanksOrderedByDescendingCompositeScore(int totalReviews, int expectedCount)
        {
            var reviews = new List<BeerReview>();
            var strategy = new Mock<IBeerRankCalculationStrategy>();
            for (var i = 0; i < totalReviews; i++)
            {
                var rv = this.Fixture.Create<BeerReview>();
                reviews.Add(rv);
            }

            var expectedGroups = reviews.Where(r => !r.IsDeleted).GroupBy(r => r.Beer);
            var enumerable = expectedGroups as IGrouping<Beer, BeerReview>[] ?? expectedGroups.ToArray();
            for (var i = 0; i < enumerable.Count(); i++)
            {
                var rank = new Mock<IBeerRank>();
                rank.SetupGet(r => r.CompositeScore)
                    .Returns(i);
                strategy.Setup(s => s.GetRank(enumerable[i], enumerable[i].Key))
                        .Returns(rank.Object);
            }

            var repository = new Mock<IRepository<BeerReview>>();
            repository.SetupGet(r => r.All)
                      .Returns(reviews.AsQueryable());

            var topBeersService = new TopBeersService(repository.Object, strategy.Object);

            var result = topBeersService.GetTopBeers(expectedCount);

            var comparer = Comparer<IBeerRank>.Create((a, b) => b.CompositeScore.CompareTo(a.CompositeScore));
            CollectionAssert.IsOrdered(result, comparer);
        }
    }
}
