using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Moq;

using NUnit.Framework;

using RememBeer.Business.Common.Contracts;
using RememBeer.Business.Top.Beers;
using RememBeer.Data.Services.Contracts;
using RememBeer.Models.Dtos;
using RememBeer.Tests.Business.Top.Fakes;

namespace RememBeer.Tests.Business.Top.Beers.Presenter
{
    [TestFixture]
    public class OnViewInitialize_Should
    {
        [Test]
        public void CallGetTopBeers()
        {
            const int TopBeersCount = 10;

            var viewModel = new MockedTopBeersViewModel();
            var view = new Mock<IInitializableView<TopBeersViewModel>>();
            view.Setup(v => v.Model).Returns(viewModel);
            var service = new Mock<ITopBeersService>();

            var presenter = new TopBeersPresenter(service.Object, view.Object);
            view.Raise(v => v.Initialized += null, view.Object, EventArgs.Empty);

            service.Verify(s => s.GetTopBeers(TopBeersCount), Times.Once);
        }

        [Test]
        public void SetModelRankingsToReturnValueOfGetTopBeers()
        {
            var expectedResult = new List<IBeerRank>();

            var viewModel = new MockedTopBeersViewModel();
            var view = new Mock<IInitializableView<TopBeersViewModel>>();
            view.Setup(v => v.Model).Returns(viewModel);

            var service = new Mock<ITopBeersService>();
            service.Setup(s => s.GetTopBeers(It.IsAny<int>())).Returns(expectedResult);

            var presenter = new TopBeersPresenter(service.Object, view.Object);
            view.Raise(v => v.Initialized += null, view.Object, EventArgs.Empty);

            Assert.AreSame(view.Object.Model.Rankings, expectedResult);
        }
    }
}
