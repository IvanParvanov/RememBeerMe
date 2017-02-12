using Moq;

using NUnit.Framework;

using Ploeh.AutoFixture;

using RememBeer.Business.Common.EventArgs.Contracts;
using RememBeer.Business.Reviews.Default;
using RememBeer.Business.Reviews.Default.Contracts;
using RememBeer.Data.Services.Contracts;
using RememBeer.Models.Contracts;
using RememBeer.Tests.Business.Reviews.Fakes;
using RememBeer.Tests.Common;

namespace RememBeer.Tests.Business.Reviews.Default.Presenter
{
    [TestFixture]
    public class OnViewinitialise_Should : TestClassBase
    {
        [Test]
        public void CallReviewServiceGetByIdMethodOnceWithCorrectParams()
        {
            var expectedId = this.Fixture.Create<int>();

            var reviewService = new Mock<IBeerReviewService>();
            var view = new Mock<IReviewDetailsView>();
            var presenter = new DefaultPresenter(reviewService.Object, view.Object);

            var args = new Mock<IIdentifiableEventArgs<int>>();
            args.Setup(a => a.Id)
                .Returns(expectedId);

            view.Raise(v => v.OnInitialise += null, view.Object, args.Object);

            reviewService.Verify(s => s.GetById(expectedId), Times.Once);
        }

        [Test]
        public void SetViewProperties_WhenReviewIsFound()
        {
            var expectedId = this.Fixture.Create<int>();
            var expectedBeerReview = new Mock<IBeerReview>();
            var reviewService = new Mock<IBeerReviewService>();
            reviewService.Setup(s => s.GetById(expectedId))
                         .Returns(expectedBeerReview.Object);

            var viewModel = new MockedBeerReviewViewModel();
            var view = new Mock<IReviewDetailsView>();
            view.Setup(v => v.Model).Returns(viewModel);

            var presenter = new DefaultPresenter(reviewService.Object, view.Object);

            var args = new Mock<IIdentifiableEventArgs<int>>();
            args.Setup(a => a.Id)
                .Returns(expectedId);

            view.Raise(v => v.OnInitialise += null, view.Object, args.Object);

            view.VerifySet(v => v.NotFoundVisible = false, Times.Once);
            Assert.AreSame(expectedBeerReview.Object, view.Object.Model.Review);
        }

        [Test]
        public void SetViewProperties_WhenReviewIsNotFound()
        {
            var expectedId = this.Fixture.Create<int>();

            var reviewService = new Mock<IBeerReviewService>();
            reviewService.Setup(s => s.GetById(expectedId))
                         .Returns((IBeerReview)null);

            var view = new Mock<IReviewDetailsView>();
            var presenter = new DefaultPresenter(reviewService.Object, view.Object);

            var args = new Mock<IIdentifiableEventArgs<int>>();
            args.Setup(a => a.Id)
                .Returns(expectedId);

            view.Raise(v => v.OnInitialise += null, view.Object, args.Object);

            view.VerifySet(v => v.NotFoundVisible = true, Times.Once);
        }
    }
}
