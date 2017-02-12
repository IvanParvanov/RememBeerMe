using System.Collections.Generic;

using NUnit.Framework;

using RememBeer.Models;

namespace RememBeer.Tests.Models
{
    [TestFixture]
    public class UserTests
    {
        [Test]
        public void Setters_ShouldSetPropertiesCorrectly()
        {
            var beers = new List<BeerReview>();
            var user = new User();
            user.BeerReviews = beers;

            Assert.AreSame(beers, user.BeerReviews);

        }

        [Test]
        public void Ctor_ShouldInitializePropertiesCorrectly()
        {
            var user = new User();

            Assert.IsNotNull(user.BeerReviews);
            Assert.IsInstanceOf<HashSet<BeerReview>>(user.BeerReviews);
        }
    }
}
