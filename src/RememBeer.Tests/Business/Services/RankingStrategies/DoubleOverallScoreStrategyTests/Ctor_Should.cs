using System;

using NUnit.Framework;

using RememBeer.Business.Services.RankingStrategies;

namespace RememBeer.Tests.Business.Services.RankingStrategies.DoubleOverallScoreStrategyTests
{
    [TestFixture]
    class Ctor_Should
    {
        [Test]
        public void ThrowArgumentNullException_WhenArgumentIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => new DoubleOverallScoreStrategy(null));
        }
    }
}
