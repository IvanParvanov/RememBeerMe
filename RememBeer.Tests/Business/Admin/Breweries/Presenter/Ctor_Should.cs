using System;

using Moq;

using NUnit.Framework;

using RememBeer.Business.Admin.Breweries;
using RememBeer.Business.Admin.Breweries.Contracts;

namespace RememBeer.Tests.Business.Admin.Breweries.Presenter
{
    [TestFixture]
    public class Ctor_Should
    {
        [Test]
        public void ThrowArgumentNullException_WhenBreweryServiceIsNull()
        {
            var view = new Mock<IBreweriesView>();

            Assert.Throws<ArgumentNullException>(() => new BreweriesPresenter(null, view.Object));
        }
    }
}
