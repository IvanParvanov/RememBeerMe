using Moq;

using NUnit.Framework;

using Ploeh.AutoFixture;

using RememBeer.Business.Admin.Brewery;
using RememBeer.Business.Admin.Brewery.Contracts;
using RememBeer.Data.Services.Contracts;
using RememBeer.Tests.Business.Mocks;
using RememBeer.Tests.Common;

namespace RememBeer.Tests.Business.Admin.Brewery.Presenter
{
    [TestFixture]
    public class OnUpdateBrewery_Should : TestClassBase
    {
        [Test]
        public void CallUpdateBreweryMethodOnceWithCorrectParams()
        {
            var expectedId = this.Fixture.Create<int>();
            var expectedName = this.Fixture.Create<string>();
            var expectedDescr = this.Fixture.Create<string>();
            var expectedCountry = this.Fixture.Create<string>();

            var viewModel = new MockedSingleBreweryViewModel();
            var view = new Mock<ISingleBreweryView>();
            view.Setup(v => v.Model)
                .Returns(viewModel);

            var args = new Mock<IBreweryUpdateEventArgs>();
            args.Setup(a => a.Id).Returns(expectedId);
            args.Setup(a => a.Description).Returns(expectedDescr);
            args.Setup(a => a.Country).Returns(expectedCountry);
            args.Setup(a => a.Name).Returns(expectedName);

            var service = new Mock<IBreweryService>();

            var presenter = new BreweryPresenter(service.Object, view.Object);
            view.Raise(v => v.BreweryUpdate += null, view.Object, args.Object);

            service.Verify(s => s.UpdateBrewery(expectedId, expectedName, expectedCountry, expectedDescr), Times.Once);
        }
    }
}
