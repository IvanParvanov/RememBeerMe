using System;

using Moq;

using NUnit.Framework;

using RememBeer.Business.Services;
using RememBeer.Data.Repositories.Base;
using RememBeer.Models;

namespace RememBeer.Tests.Business.Services.BreweryServiceTests
{
    [TestFixture]
    public class Ctor_Should
    {
        [Test]
        public void ThrowArgumentNullException_WhenBreweryRepositoryIsNull()
        {
            var beerRepo = new Mock<IRepository<Beer>>();

            Assert.Throws<ArgumentNullException>(() => new BreweryService(null, beerRepo.Object));
        }

        [Test]
        public void ThrowArgumentNullException_WhenBeerRepositoryIsNull()
        {
            var breweryRepo = new Mock<IRepository<Brewery>>();

            Assert.Throws<ArgumentNullException>(() => new BreweryService(breweryRepo.Object, null));
        }
    }
}
