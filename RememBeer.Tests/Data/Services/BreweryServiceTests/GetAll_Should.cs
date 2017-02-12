using System.Collections.Generic;

using Moq;

using NUnit.Framework;

using RememBeer.Data.Repositories.Base;
using RememBeer.Data.Services;
using RememBeer.Models;
using RememBeer.Models.Contracts;

namespace RememBeer.Tests.Data.Services.BreweryServiceTests
{
    public class GetAll_Should
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

        [Test]
        public void CallOrderBySkipAndTakeLinqMethods()
        {
            //TODO:
            //var expected = new List<Brewery>();
            //var repository = new Mock<IRepository<Brewery>>();
            //repository.Setup(r => r.GetAll())
            //          .Returns(expected);

            //var service = new BreweryService(repository.Object);

            //var actual = service.GetAll();
            //Assert.AreSame(expected, actual);
        }
    }
}
