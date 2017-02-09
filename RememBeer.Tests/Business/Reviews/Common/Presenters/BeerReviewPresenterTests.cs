using System;

using Moq;

using NUnit.Framework;

using RememBeer.Business.Account.Register.Contracts;
using RememBeer.Business.Reviews.Common.Presenters;
using RememBeer.Business.Services;

namespace RememBeer.Tests.Business.Reviews.Common.Presenters
{
    [TestFixture]
    public class BeerReviewPresenterTests
    {
        [Test]
        public void Ctor_ShouldThrowArgumentNullException_WhenServiceIsNull()
        {
            var view = new Mock<IRegisterView>();
            Assert.Throws<ArgumentNullException>(
                                                 () =>
                                                     new BeerReviewPresenter<IRegisterView>(null,
                                                                                            view.Object));
        }

        [Test]
        public void Ctor_SetReviewService()
        {
            var view = new Mock<IRegisterView>();
            var service = new Mock<IBeerReviewService>();
            var presenter = new MockedBeerReviewPresenter(service.Object, view.Object);

            Assert.AreSame(service.Object, presenter.ActualReviewService);
        }
    }

    public class MockedBeerReviewPresenter : BeerReviewPresenter<IRegisterView>
    {
        public MockedBeerReviewPresenter(IBeerReviewService reviewService, IRegisterView view) 
            : base(reviewService, view)
        {
        }

        public IBeerReviewService ActualReviewService { get { return base.ReviewService; } }
    }
}
