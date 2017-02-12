using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;

using RememBeer.Data.Services;

namespace RememBeer.Tests.Data.Services.BreweryServiceTests
{
    [TestFixture]
    public class Ctor_Should
    {
        [Test]
        public void ThrowArgumentNullException_WhenRepositoryIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => new BreweryService(null));
        }
    }
}
