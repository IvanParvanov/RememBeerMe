using System;

using NUnit.Framework;

using RememBeer.Business.Services;

namespace RememBeer.Tests.Business.Services.BeerReviewServiceTests
{
    [TestFixture]
    public class Ctor_Should
    {
        [Test]
        public void ThrowArgumentNullException_WhenRepositoryIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => new BeerReviewService(null));
        }
    }
}
