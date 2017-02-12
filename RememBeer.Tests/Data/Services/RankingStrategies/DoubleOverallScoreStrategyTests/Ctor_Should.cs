using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;

using RememBeer.Data.Services.RankingStrategies;

namespace RememBeer.Tests.Data.Services.RankingStrategies.DoubleOverallScoreStrategyTests
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
