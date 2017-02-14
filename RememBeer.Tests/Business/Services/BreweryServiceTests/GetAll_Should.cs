using System;
using System.Collections.Generic;
using System.Linq;

using Moq;

using NUnit.Framework;

using Ploeh.AutoFixture;

using RememBeer.Business.Services;
using RememBeer.Common.Identity.Contracts;
using RememBeer.Common.Identity.Models;
using RememBeer.Data.Repositories.Base;
using RememBeer.Models;
using RememBeer.Models.Contracts;
using RememBeer.Models.Factories;
using RememBeer.Tests.Business.Mocks;
using RememBeer.Tests.Common;

namespace RememBeer.Tests.Business.Services.BreweryServiceTests
{
    [TestFixture]
    public class GetAll_Should : TestClassBase
    {
        [Test]
        public void CallRepositoryGetAllMethodOnce()
        {
            var repository = new Mock<IRepository<Brewery>>();

            var service = new BreweryService(repository.Object);

            service.GetAll();

            repository.Verify(r => r.GetAll(), Times.Once);
        }

        [Test]
        public void ReturnResultFromRepositoryGetAllMethod()
        {
            var expected = new List<Brewery>();
            var repository = new Mock<IRepository<Brewery>>();
            repository.Setup(r => r.GetAll())
                      .Returns(expected);

            var service = new BreweryService(repository.Object);

            var actual = service.GetAll();
            Assert.AreSame(expected, actual);
        }

        [TestCase(2, 4, 15)]
        [TestCase(0, 4, 15)]
        [TestCase(4, 4, 20)]
        [TestCase(0, 10, 15)]
        public void ReturnCorrectResult_WhenPaginated(int currentPage,
                                                      int expectedPageSize,
                                                      int expectedTotalCount)
        {
            var breweryComparer =
                Comparer<IBrewery>.Create(((a, b) => string.Compare(a.Name, b.Name, StringComparison.Ordinal)));

            var breweries = new List<Brewery>();
            for (var i = 0; i < expectedTotalCount; i++)
            {
                breweries.Add(new Brewery()
                          {
                              Name = this.Fixture.Create<string>()
                          });
            }

            var queryableBreweries = breweries.AsQueryable();
            var repository = new Mock<IRepository<Brewery>>();
            repository.Setup(r => r.All)
                       .Returns(queryableBreweries);

            var service = new BreweryService(repository.Object);
            var result = service.GetAll(currentPage, expectedPageSize, (a) => a.Name);

            var actualUsers = result as IBrewery[] ?? result.ToArray();
            var actualCount = actualUsers.Count();

            Assert.GreaterOrEqual(expectedPageSize, actualCount);
            CollectionAssert.IsOrdered(actualUsers, breweryComparer);
        }
    }
}
