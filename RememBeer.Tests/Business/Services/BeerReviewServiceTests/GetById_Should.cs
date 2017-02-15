using Moq;

using NUnit.Framework;

using Ploeh.AutoFixture;

using RememBeer.Business.Services;
using RememBeer.Data.Repositories.Base;
using RememBeer.Models;
using RememBeer.Tests.Common;

namespace RememBeer.Tests.Business.Services.BeerReviewServiceTests
{
    [TestFixture]
    public class GetById_Should : TestClassBase
    {
        [Test]
        public void Call_RepositoryGetByIdMethodOnceWithCorrectParams()
        {
            var id = this.Fixture.Create<string>();
            var repository = new Mock<IRepository<BeerReview>>();
            var reviewService = new BeerReviewService(repository.Object);

            reviewService.GetById(id);

            repository.Verify(r => r.GetById(id), Times.Once);
        }

        [Test]
        public void ReturnResultFrom_RepositoryGetByIdMethod()
        {
            var id = this.Fixture.Create<string>();
            var expected = new BeerReview();
            var repository = new Mock<IRepository<BeerReview>>();
            repository.Setup(r => r.GetById(It.IsAny<object>()))
                      .Returns(expected);

            var reviewService = new BeerReviewService(repository.Object);

            var actual = reviewService.GetById(id);

            Assert.AreSame(expected, actual);
        }
    }
}
