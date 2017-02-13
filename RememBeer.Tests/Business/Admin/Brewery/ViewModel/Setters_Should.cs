using Moq;

using NUnit.Framework;

using RememBeer.Business.Admin.Brewery;
using RememBeer.Models.Contracts;

namespace RememBeer.Tests.Business.Admin.Brewery.ViewModel
{
    [TestFixture]
    public class Setters_Should 
    {
        [Test]
        public void SetPropertiesCorrectly()
        {
            var brewery = new Mock<IBrewery>();
            var viewModel = new SingleBreweryViewModel();

            viewModel.Brewery = brewery.Object;

            Assert.AreSame(brewery.Object, viewModel.Brewery);
        }
    }
}
