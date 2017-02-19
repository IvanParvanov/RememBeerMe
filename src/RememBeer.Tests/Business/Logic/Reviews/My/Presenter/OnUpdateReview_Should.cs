﻿using Moq;

using NUnit.Framework;

using Ploeh.AutoFixture;

using RememBeer.Business.Logic.Reviews.My;
using RememBeer.Business.Logic.Reviews.My.Contracts;
using RememBeer.Business.Services.Contracts;
using RememBeer.Data.Repositories;
using RememBeer.Models.Contracts;
using RememBeer.Tests.Common;
using RememBeer.Tests.Common.MockedClasses;

namespace RememBeer.Tests.Business.Logic.Reviews.My.Presenter
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

            var result = new Mock<IDataModifiedResult>();
            result.Setup(r => r.Successful).Returns(false);

            var reviewService = new Mock<IBeerReviewService>();
            reviewService.Setup(s => s.UpdateReview(review.Object))
                         .Returns(result.Object);

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

            var result = new Mock<IDataModifiedResult>();
            result.Setup(r => r.Successful).Returns(true);

            var reviewService = new Mock<IBeerReviewService>();
            reviewService.Setup(s => s.UpdateReview(review.Object))
                         .Returns(result.Object);

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

            var review = new Mock<IBeerReview>();
            var args = new Mock<IBeerReviewInfoEventArgs>();
            args.Setup(a => a.BeerReview).Returns(review.Object);

            var view = new Mock<IMyReviewsView>();

            var result = new Mock<IDataModifiedResult>();
            result.Setup(r => r.Successful).Returns(false);
            result.Setup(r => r.Errors).Returns(new[] { expectedMessage });

            var reviewService = new Mock<IBeerReviewService>();
            reviewService.Setup(s => s.UpdateReview(review.Object))
                         .Returns(result.Object);

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