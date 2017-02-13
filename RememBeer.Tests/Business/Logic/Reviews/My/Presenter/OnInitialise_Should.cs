﻿using System.Collections.Generic;

using Moq;

using NUnit.Framework;

using RememBeer.Business.Logic.Reviews.My;
using RememBeer.Business.Logic.Reviews.My.Contracts;
using RememBeer.Business.Services.Contracts;
using RememBeer.Models;
using RememBeer.Tests.Common;
using RememBeer.Tests.Common.MockedClasses;

namespace RememBeer.Tests.Business.Logic.Reviews.My.Presenter
{
    [TestFixture]
    public class OnInitialise_Should : TestClassBase
    {
        [Test]
        public void ShouldSetModelReviewsCorrectly()
        {
            var expectedReviews = new List<BeerReview>();
            var viewModel = new ReviewsViewModel()
                            {
                                Reviews = expectedReviews
                            };
            var view = new Mock<IMyReviewsView>();
            view.SetupGet(v => v.Model).Returns(viewModel);

            var reviewService = new Mock<IBeerReviewService>();
            reviewService.Setup(s => s.GetReviewsForUser(null))
                         .Returns(expectedReviews);

            var httpResponse = new MockedHttpResponse();
            var presenter = new MyReviewsPresenter(reviewService.Object, view.Object)
            {
                HttpContext = new MockedHttpContextBase(httpResponse)
            };

            view.Raise(v => v.Initialized += null, view.Object, System.EventArgs.Empty);

            Assert.AreSame(view.Object.Model.Reviews, expectedReviews);
        }

        [Test]
        public void ShouldHideSuccessMessage()
        {
            var expectedReviews = new List<BeerReview>();
            var viewModel = new ReviewsViewModel()
            {
                Reviews = expectedReviews
            };
            var view = new Mock<IMyReviewsView>();
            view.SetupGet(v => v.Model).Returns(viewModel);
            view.SetupSet(v => v.SuccessMessageVisible = false);
            var reviewService = new Mock<IBeerReviewService>();
            reviewService.Setup(s => s.GetReviewsForUser(null))
                         .Returns(expectedReviews);

            var httpResponse = new MockedHttpResponse();
            var presenter = new MyReviewsPresenter(reviewService.Object, view.Object)
            {
                HttpContext = new MockedHttpContextBase(httpResponse)
            };

            view.Raise(v => v.Initialized += null, view.Object, System.EventArgs.Empty);

            view.VerifySet(v => v.SuccessMessageVisible = false, Times.Once());
        }
    }
}