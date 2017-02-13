using System.Collections.Generic;

using Moq;

using NUnit.Framework;

using Ploeh.AutoFixture;

using RememBeer.Business.Logic.Admin.Breweries;
using RememBeer.Business.Logic.Admin.Breweries.Contracts;
using RememBeer.Business.Logic.Common.EventArgs.Contracts;
using RememBeer.Business.Services.Contracts;
using RememBeer.Models.Contracts;
using RememBeer.Tests.Business.Mocks;
using RememBeer.Tests.Common;

namespace RememBeer.Tests.Business.Logic.Admin.Breweries.Presenter
{
    [TestFixture]
    public class OnViewSearch_Should: TestClassBase
    {
        [Test]
        public void CallBreweryServiceSearchMethodOnceWithCorrectParams()
        {
            var expectedPattern = this.Fixture.Create<string>();

            var viewModel = new MockedBreweriesViewModel();
            var view = new Mock<IBreweriesView>();
            view.Setup(v => v.Model)
                .Returns(viewModel);

            var service = new Mock<IBreweryService>();

            var presenter = new BreweriesPresenter(service.Object, view.Object);

            var args = new Mock<ISearchEventArgs>();
            args.Setup(a => a.Pattern).Returns(expectedPattern);

            view.Raise(v => v.BrewerySearch += null, view.Object, args.Object);

            service.Verify(s => s.Search(expectedPattern), Times.Once);
        }

        [Test]
        public void SetResultFromServiceToViewModel()
        {
            var expectedPattern = this.Fixture.Create<string>();
            var expectedBreweries = new List<IBrewery>();

            var viewModel = new MockedBreweriesViewModel();
            var view = new Mock<IBreweriesView>();
            view.Setup(v => v.Model)
                .Returns(viewModel);

            var service = new Mock<IBreweryService>();
            service.Setup(s => s.Search(expectedPattern))
                   .Returns(expectedBreweries);
            var presenter = new BreweriesPresenter(service.Object, view.Object);

            var args = new Mock<ISearchEventArgs>();
            args.Setup(a => a.Pattern).Returns(expectedPattern);

            view.Raise(v => v.BrewerySearch += null, view.Object, args.Object);

            Assert.AreSame(expectedBreweries, view.Object.Model.Breweries);
        }
    }
}
