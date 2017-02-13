using System;
using System.Collections.Generic;

using Moq;

using NUnit.Framework;

using RememBeer.Business.Admin.Breweries;
using RememBeer.Business.Admin.Breweries.Contracts;
using RememBeer.Data.Services.Contracts;
using RememBeer.Models.Contracts;
using RememBeer.Tests.Business.Mocks;
using RememBeer.Tests.Common;

namespace RememBeer.Tests.Business.Admin.Breweries.Presenter
{
    [TestFixture]
    public class OnViewInitialized_Should : TestClassBase
    {
        [Test]
        public void CallBreweryServiceGetAllMethodOnce()
        {
            var viewModel = new MockedBreweriesViewModel();
            var view = new Mock<IBreweriesView>();
            view.Setup(v => v.Model)
                .Returns(viewModel);

            var service = new Mock<IBreweryService>();

            var presenter = new BreweriesPresenter(service.Object, view.Object);

            view.Raise(v => v.Initialized += null, view.Object, EventArgs.Empty);

            service.Verify(s => s.GetAll(), Times.Once);
        }

        [Test]
        public void SetResultFromServiceToViewModel()
        {
            var expectedBreweries = new List<IBrewery>();

            var viewModel = new MockedBreweriesViewModel();
            var view = new Mock<IBreweriesView>();
            view.Setup(v => v.Model)
                .Returns(viewModel);

            var service = new Mock<IBreweryService>();
            service.Setup(s => s.GetAll())
                   .Returns(expectedBreweries);
            var presenter = new BreweriesPresenter(service.Object, view.Object);

            view.Raise(v => v.Initialized += null, view.Object, EventArgs.Empty);

            Assert.AreSame(expectedBreweries, view.Object.Model.Breweries);
        }
    }
}
