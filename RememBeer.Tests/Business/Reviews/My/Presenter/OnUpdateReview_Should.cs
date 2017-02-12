using System;

using Moq;

using NUnit.Framework;

using Ploeh.AutoFixture;

using RememBeer.Business.Reviews.My;
using RememBeer.Business.Reviews.My.Contracts;
using RememBeer.Data.Services.Contracts;
using RememBeer.Models.Contracts;
using RememBeer.Tests.Common;
using RememBeer.Tests.Common.MockedClasses;

namespace RememBeer.Tests.Business.Reviews.My.Presenter
{
    [TestFixture]
    public class OnUpdateReview_Should : TestClassBase
    {
        [Test]
        public void CallUpdateReviewMethodOnce()
        {
            var review = new Mock<IBeerReview>();
            var args = new Mock<IBeerReviewInfoEventArgs>();
            args.Setup(a => a.BeerReview).Returns(review.Object);

            var view = new Mock<IMyReviewsView>();

            var reviewService = new Mock<IBeerReviewService>();
            reviewService.Setup(s => s.UpdateReview(review.Object));

            var httpResponse = new MockedHttpResponse();
            var presenter = new MyReviewsPresenter(reviewService.Object, view.Object)
            {
                HttpContext = new MockedHttpContextBase(httpResponse)
            };

            view.Raise(v => v.ReviewUpdate += null, view.Object, args.Object);

            reviewService.Verify(s => s.UpdateReview(review.Object), Times.Once);
        }

        [Test]
        public void SetViewPropertiesCorrectly()
        {
            const string ExpectedMessage = "Review successfully updated!";
            var review = new Mock<IBeerReview>();
            var args = new Mock<IBeerReviewInfoEventArgs>();
            args.Setup(a => a.BeerReview).Returns(review.Object);

            var view = new Mock<IMyReviewsView>();

            var reviewService = new Mock<IBeerReviewService>();
            reviewService.Setup(s => s.UpdateReview(review.Object));

            var httpResponse = new MockedHttpResponse();
            var presenter = new MyReviewsPresenter(reviewService.Object, view.Object)
            {
                HttpContext = new MockedHttpContextBase(httpResponse)
            };

            view.Raise(v => v.ReviewUpdate += null, view.Object, args.Object);

            view.VerifySet(v => v.SuccessMessageText = ExpectedMessage, Times.Once);
            view.VerifySet(v => v.SuccessMessageVisible = true, Times.Once);
        }

        [Test]
        public void CatchUpdateExceptionAndSetViewProperties()
        {
            var expectedMessage = this.Fixture.Create<string>();
            var exception = new Exception(expectedMessage);

            var review = new Mock<IBeerReview>();
            var args = new Mock<IBeerReviewInfoEventArgs>();
            args.Setup(a => a.BeerReview).Returns(review.Object);

            var view = new Mock<IMyReviewsView>();

            var reviewService = new Mock<IBeerReviewService>();
            reviewService.Setup(s => s.UpdateReview(review.Object)).Throws(exception);

            var httpResponse = new MockedHttpResponse();
            var presenter = new MyReviewsPresenter(reviewService.Object, view.Object)
            {
                HttpContext = new MockedHttpContextBase(httpResponse)
            };

            view.Raise(v => v.ReviewUpdate += null, view.Object, args.Object);

            view.VerifySet(v => v.SuccessMessageText = expectedMessage, Times.Once);
            view.VerifySet(v => v.SuccessMessageVisible = true, Times.Once);
        }
    }
}
