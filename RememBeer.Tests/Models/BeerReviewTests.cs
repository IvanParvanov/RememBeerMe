using System;

using NUnit.Framework;

using RememBeer.Models;

namespace RememBeer.Tests.Models
{
    [TestFixture]
    public class BeerReviewTests
    {
        [Test]
        public void Setters_ShouldSetUpPropertiesCorrectly()
        {
            var expectedId = 100;
            var expectedText = "kasdjkasdljkasdljasd";
            var isPublic = true;
            var expectedDate = DateTime.Now;
            var review = new BeerReview()
                         {
                             Id = expectedId,
                             Overall = expectedId,
                             Look = expectedId,
                             Smell = expectedId,
                             Taste = expectedId,
                             Description = expectedText,
                             IsPublic = isPublic,
                             Place = expectedText,
                             Beer = null,
                             CreatedAt = expectedDate,
                             ModifiedAt = expectedDate
                         };

            Assert.AreEqual(expectedId, review.Id);
            Assert.AreEqual(expectedId, review.Overall);
            Assert.AreEqual(expectedId, review.Look);
            Assert.AreEqual(expectedId, review.Smell);
            Assert.AreEqual(expectedId, review.Taste);
            Assert.AreEqual(isPublic, review.IsPublic);

            Assert.AreSame(expectedText, review.Description);
            Assert.AreSame(expectedText, review.Place);
            Assert.AreSame(null, review.Beer);
            Assert.AreEqual(expectedDate, review.CreatedAt);
            Assert.AreEqual(expectedDate, review.ModifiedAt);

        }
    }
}
