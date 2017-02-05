﻿using System.Collections.Generic;

using NUnit.Framework;

using RememBeer.Models;

namespace RememBeer.Tests.Models
{
    [TestFixture]
    public class BeerTests
    {
        [Test]
        public void Setters_ShouldSetPropertiesCorrectly()
        {
            var expectedId = 1;
            var beer = new Beer()
                       {
                           Id = expectedId,
                           Brewery = null,
                           Type = null

                       };

            Assert.AreEqual(expectedId, beer.Id);
            Assert.AreEqual(null, beer.Brewery);
            Assert.AreEqual(null, beer.Type);
            Assert.IsInstanceOf<HashSet<BeerReview>>(beer.Reviews);
        }
    }
}