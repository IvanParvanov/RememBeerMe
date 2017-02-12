using Moq;

using NUnit.Framework;

using RememBeer.Business.Reviews.My;
using RememBeer.Models.Contracts;
using RememBeer.Tests.Common;

namespace RememBeer.Tests.Business.Reviews.My.EventArgs
{
    [TestFixture]
   public class Ctor_Should : TestClassBase
    {
        [Test]
        public void SetUpPropertiesCorrectly()
        {
            var review = new Mock<IBeerReview>();
            var image = new byte[1];

            var args = new BeerReviewInfoEventArgs(review.Object, image);

            Assert.AreSame(review.Object, args.BeerReview);
            Assert.AreSame(image, args.Image);
        }

        [Test]
        public void SetUpPropertiesCorrectly_WhenCalledWithOneArg()
        {
            var review = new Mock<IBeerReview>();

            var args = new BeerReviewInfoEventArgs(review.Object);

            Assert.AreSame(review.Object, args.BeerReview);
        }
    }
}
