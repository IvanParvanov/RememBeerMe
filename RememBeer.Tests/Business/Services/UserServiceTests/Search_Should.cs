using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Moq;

using NUnit.Framework;

using Ploeh.AutoFixture;

using RememBeer.Business.Services;
using RememBeer.Data.Repositories.Base;
using RememBeer.Models;
using RememBeer.Models.Contracts;
using RememBeer.Tests.Common;

namespace RememBeer.Tests.Business.Services.UserServiceTests
{
    [TestFixture]
    public class Search_Should : TestClassBase
    {
        [TestCase(0)]
        [TestCase(10)]
        [TestCase(23)]
        [TestCase(30)]
        public void ReturnFilteredSetOfBreweries(int expectedTotalCount)
        {
            var pattern = this.Fixture.Create<string>();
            var expectedFoundCount = expectedTotalCount / 5;
            var countryCount = expectedFoundCount / 2;
            var nameCount = countryCount;

            var breweries = new List<Brewery>();
            for (var i = 0; i < expectedTotalCount - expectedFoundCount; i++)
            {
                breweries.Add(new Brewery()
                              {
                                  Name = this.Fixture.Create<string>(),
                                  Country = this.Fixture.Create<string>()
                              });
            }

            for (int i = 0; i < countryCount; i++)
            {
                breweries.Add(new Brewery()
                              {
                                  Name = this.Fixture.Create<string>(),
                                  Country = this.Fixture.Create<string>() + pattern + this.Fixture.Create<string>()
                              });
            }

            for (int i = 0; i < nameCount; i++)
            {
                breweries.Add(new Brewery()
                              {
                                  Country = this.Fixture.Create<string>(),
                                  Name = this.Fixture.Create<string>() + pattern + this.Fixture.Create<string>()
                              });
            }

            var queryableBreweries = breweries.AsQueryable();
            var repository = new Mock<IRepository<Brewery>>();
            repository.Setup(r => r.All)
                      .Returns(queryableBreweries);

            var service = new BreweryService(repository.Object);
            var result = service.Search(pattern);

            var actualBreweries = result as IBrewery[] ?? result.ToArray();
            var actualCount = actualBreweries.Count();

            Assert.GreaterOrEqual(expectedFoundCount, actualCount);
            foreach (var actualBrewery in actualBreweries)
            {
                Assert.IsTrue(actualBrewery.Name.Contains(pattern) || actualBrewery.Country.Contains(pattern));
            }
        }
    }
}
