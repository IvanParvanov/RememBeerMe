using System.Collections.Generic;

using Moq;

using NUnit.Framework;

using Ploeh.AutoFixture;

using RememBeer.Business.Logic.Common.EventArgs.Contracts;
using RememBeer.Business.Logic.Reviews.My;
using RememBeer.Business.Logic.Reviews.My.Contracts;
using RememBeer.Business.Services.Contracts;
using RememBeer.Models;
using RememBeer.Tests.Common;
using RememBeer.Tests.Common.MockedClasses;

namespace RememBeer.Tests.Business.Logic.Reviews.My.Presenter
{
    [TestFixture]
    public class OnViewInitialise_Should : TestClassBase
    {
        [Test]
        public void Call_GetReviewsForUserWithCorrectParamsOnce()
        {
            var startRow = this.Fixture.Create<int>();
            var pageSize = this.Fixture.Create<int>();
            var expectedReviews = new List<BeerReview>();
            var viewModel = new ReviewsViewModel()
            {
                Reviews = expectedReviews
            };
            var view = new Mock<IMyReviewsView>();
            view.SetupGet(v => v.Model).Returns(viewModel);
            view.SetupSet(v => v.SuccessMessageVisible = false);
            var reviewService = new Mock<IBeerReviewService>();
            reviewService.Setup(s => s.GetReviewsForUser(null, startRow, pageSize))
                         .Returns(expectedReviews);
            var args = new Mock<IPaginationEventArgs>();
            args.Setup(a => a.PageSize)
                .Returns(pageSize);
            args.Setup(a => a.StartRowIndex)
                .Returns(startRow);

            var httpResponse = new MockedHttpResponse();
            var presenter = new MyReviewsPresenter(reviewService.Object, view.Object)
            {
                HttpContext = new MockedHttpContextBase(httpResponse)
            };

            view.Raise(v => v.Initialized += null, view.Object, args.Object);

           reviewService.Verify(r => r.GetReviewsForUser(null, startRow, pageSize), Times.Once());
        }

        [Test]
        public void Set_ViewModelTotalCountPropertyToReturnValueFromCountUserReviews()
        {
            var startRow = this.Fixture.Create<int>();
            var pageSize = this.Fixture.Create<int>();
            var expectedTotalCount = this.Fixture.Create<int>();

            var expectedReviews = new List<BeerReview>();
            var viewModel = new ReviewsViewModel()
            {
                Reviews = expectedReviews
            };
            var view = new Mock<IMyReviewsView>();
            view.SetupGet(v => v.Model).Returns(viewModel);
            view.SetupSet(v => v.SuccessMessageVisible = false);
            var reviewService = new Mock<IBeerReviewService>();
            reviewService.Setup(s => s.GetReviewsForUser(null, startRow, pageSize))
                         .Returns(expectedReviews);
            reviewService.Setup(s => s.CountUserReviews(It.IsAny<string>()))
                         .Returns(expectedTotalCount);
            var args = new Mock<IPaginationEventArgs>();
            args.Setup(a => a.PageSize)
                .Returns(pageSize);
            args.Setup(a => a.StartRowIndex)
                .Returns(startRow);

            var httpResponse = new MockedHttpResponse();
            var presenter = new MyReviewsPresenter(reviewService.Object, view.Object)
            {
                HttpContext = new MockedHttpContextBase(httpResponse)
            };

            view.Raise(v => v.Initialized += null, view.Object, args.Object);

            Assert.AreEqual(expectedTotalCount, viewModel.TotalCount);
        }

        [Test]
        public void Set_ModelReviewsCorrectly()
        {
            var startRow = this.Fixture.Create<int>();
            var pageSize = this.Fixture.Create<int>();
            var expectedReviews = new List<BeerReview>();
            var viewModel = new ReviewsViewModel()
                            {
                                Reviews = expectedReviews
                            };
            var view = new Mock<IMyReviewsView>();
            view.SetupGet(v => v.Model).Returns(viewModel);

            var reviewService = new Mock<IBeerReviewService>();
            reviewService.Setup(s => s.GetReviewsForUser(null, It.IsAny<int>(), It.IsAny<int>()))
                         .Returns(expectedReviews);

            var httpResponse = new MockedHttpResponse();
            var presenter = new MyReviewsPresenter(reviewService.Object, view.Object)
                            {
                                HttpContext = new MockedHttpContextBase(httpResponse)
                            };
            var args = new Mock<IPaginationEventArgs>();
            args.Setup(a => a.PageSize)
                .Returns(pageSize);
            args.Setup(a => a.StartRowIndex)
                .Returns(startRow);

            view.Raise(v => v.Initialized += null, view.Object, args.Object);

            Assert.AreSame(view.Object.Model.Reviews, expectedReviews);
        }

        [Test]
        public void Hide_SuccessMessage()
        {
            var startRow = this.Fixture.Create<int>();
            var pageSize = this.Fixture.Create<int>();
            var expectedReviews = new List<BeerReview>();
            var viewModel = new ReviewsViewModel()
                            {
                                Reviews = expectedReviews
                            };
            var view = new Mock<IMyReviewsView>();
            view.SetupGet(v => v.Model).Returns(viewModel);
            view.SetupSet(v => v.SuccessMessageVisible = false);
            var reviewService = new Mock<IBeerReviewService>();
            reviewService.Setup(s => s.GetReviewsForUser(null, It.IsAny<int>(), It.IsAny<int>()))
                         .Returns(expectedReviews);
            var args = new Mock<IPaginationEventArgs>();
            args.Setup(a => a.PageSize)
                .Returns(pageSize);
            args.Setup(a => a.StartRowIndex)
                .Returns(startRow);

            var httpResponse = new MockedHttpResponse();
            var presenter = new MyReviewsPresenter(reviewService.Object, view.Object)
                            {
                                HttpContext = new MockedHttpContextBase(httpResponse)
                            };

            view.Raise(v => v.Initialized += null, view.Object, args.Object);

            view.VerifySet(v => v.SuccessMessageVisible = false, Times.Once());
        }
    }
}
