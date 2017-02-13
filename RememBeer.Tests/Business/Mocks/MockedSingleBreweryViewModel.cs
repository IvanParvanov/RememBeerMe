using RememBeer.Business.Admin.Brewery;
using RememBeer.Models.Contracts;

namespace RememBeer.Tests.Business.Mocks
{
    public class MockedSingleBreweryViewModel : SingleBreweryViewModel
    {
        public override IBrewery Brewery { get; set; }
    }
}
