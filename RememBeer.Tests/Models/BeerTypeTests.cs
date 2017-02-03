using NUnit.Framework;

using RememBeer.Models;

namespace RememBeer.Tests.Models
{
    [TestFixture]
    public class BeerTypeTests
    {
        [Test]
        public void Setters_ShouldSetPropertiesCorrectly()
        {
            var expectedId = 1;
            var expectedType =  "sdadasdasdas";
            var beer = new BeerType()
            {
                Id = expectedId,
                Type = expectedType

            };

            Assert.AreEqual(expectedId, beer.Id);
            Assert.AreEqual(expectedType, beer.Type);
        }
    }
}
