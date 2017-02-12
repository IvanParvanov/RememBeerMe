using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Moq;

using NUnit.Framework.Internal;

using RememBeer.Tests.Common;
using NUnit.Framework;

using Ploeh.AutoFixture;

using RememBeer.Business.Reviews.My;
using RememBeer.Business.Reviews.My.Contracts;
using RememBeer.Data.Services.Contracts;
using RememBeer.Models;
using RememBeer.Models.Contracts;
using RememBeer.Tests.Common.MockedClasses;

namespace RememBeer.Tests.Business.Reviews.My.Presenter
{
    [TestFixture]
   public class OnDeleteReview_Should : TestClassBase
    {
        [Test]
        public void CallServiceDeleteReviewMethodOnce_WithCorrectParameter()
        {
            var reviewId = this.Fixture.Create<int>();

            var review = new Mock<IBeerReview>();
            review.Setup(r => r.Id)
                  .Returns(reviewId);
            var args = new Mock<IBeerReviewInfoEventArgs>();
            args.Setup(a => a.BeerReview)
                .Returns(review.Object);

            var expectedReviews = new List<IBeerReview>()
                                  {
                                      review.Object
                                  };
            var viewModel = new ReviewsViewModel()
            {
                Reviews = expectedReviews
            };

            var view = new Mock<IMyReviewsView>();
            view.SetupGet(v => v.Model).Returns(viewModel);

            var reviewService = new Mock<IBeerReviewService>();
            reviewService.Setup(s => s.DeleteReview(reviewId));

            var httpResponse = new MockedHttpResponse();
            var presenter = new MyReviewsPresenter(reviewService.Object, view.Object)
            {
                HttpContext = new MockedHttpContextBase(httpResponse)
            };

            view.Raise(v => v.ReviewDelete += null, view.Object, args.Object);

            reviewService.Verify(s => s.DeleteReview(reviewId), Times.Once);
        }

        [Test]
        public void FilterViewModelsReviewsByDeletion()
        {
            var reviewId = this.Fixture.Create<int>();

            var review = new Mock<IBeerReview>();
            review.Setup(r => r.Id)
                  .Returns(reviewId);
            review.Setup(r => r.IsDeleted)
                  .Returns(true);

            var args = new Mock<IBeerReviewInfoEventArgs>();
            args.Setup(a => a.BeerReview)
                .Returns(review.Object);

            var expectedReviews = new List<IBeerReview>()
                                  {
                                      review.Object
                                  };
            var viewModel = new ReviewsViewModel()
            {
                Reviews = expectedReviews
            };

            var view = new Mock<IMyReviewsView>();
            view.SetupGet(v => v.Model).Returns(viewModel);

            var reviewService = new Mock<IBeerReviewService>();
            reviewService.Setup(s => s.DeleteReview(reviewId));

            var httpResponse = new MockedHttpResponse();
            var presenter = new MyReviewsPresenter(reviewService.Object, view.Object)
            {
                HttpContext = new MockedHttpContextBase(httpResponse)
            };

            view.Raise(v => v.ReviewDelete += null, view.Object, args.Object);

            CollectionAssert.IsEmpty(viewModel.Reviews);
        }

        [Test]
        public void SetViewMessagesCorrectly()
        {
            const string ExpectedMessage = "Review deleted!";

            var reviewId = this.Fixture.Create<int>();

            var review = new Mock<IBeerReview>();
            review.Setup(r => r.Id)
                  .Returns(reviewId);

            var args = new Mock<IBeerReviewInfoEventArgs>();
            args.Setup(a => a.BeerReview)
                .Returns(review.Object);

            var expectedReviews = new List<IBeerReview>()
                                  {
                                      review.Object
                                  };
            var viewModel = new ReviewsViewModel()
            {
                Reviews = expectedReviews
            };

            var view = new Mock<IMyReviewsView>();
            view.SetupGet(v => v.Model).Returns(viewModel);

            var reviewService = new Mock<IBeerReviewService>();
            reviewService.Setup(s => s.DeleteReview(reviewId));

            var httpResponse = new MockedHttpResponse();
            var presenter = new MyReviewsPresenter(reviewService.Object, view.Object)
            {
                HttpContext = new MockedHttpContextBase(httpResponse)
            };

            view.Raise(v => v.ReviewDelete += null, view.Object, args.Object);

            view.VerifySet(v => v.SuccessMessageText = ExpectedMessage, Times.Once);
            view.VerifySet(v => v.SuccessMessageVisible = true, Times.Once);
        }
    }
}
