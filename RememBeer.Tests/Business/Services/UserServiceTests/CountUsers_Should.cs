using System.Collections.Generic;
using System.Linq;

using Moq;

using NUnit.Framework;

using RememBeer.Business.Services;
using RememBeer.Common.Identity.Contracts;
using RememBeer.Common.Identity.Models;
using RememBeer.Data.Repositories.Base;
using RememBeer.Models.Factories;
using RememBeer.Tests.Business.Mocks;

namespace RememBeer.Tests.Business.Services.UserServiceTests
{
    [TestFixture]
    public class CountUsers_Should
    {
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(7)]
        [TestCase(13)]
        [TestCase(23)]
        public void ReturnCorrectRepositoryCount(int userCount)
        {
            var users = new List<MockedApplicationUser>();
            for (var i = 0; i < userCount; i++)
            {
                users.Add(new MockedApplicationUser());
            }

            var queryableUsers = users.AsQueryable();

            var expectedCount = users.Count();

            var userManager = new Mock<IApplicationUserManager>();
            var signInManager = new Mock<IApplicationSignInManager>();
            var repository = new Mock<IRepository<ApplicationUser>>();
            repository.Setup(r => r.All)
                      .Returns(queryableUsers);

            var modelFactory = new Mock<IModelFactory>();

            var service = new UserService(userManager.Object,
                                          signInManager.Object,
                                          repository.Object,
                                          modelFactory.Object);

            var result = service.CountUsers();

            Assert.AreEqual(expectedCount, result);
            repository.VerifyGet(r => r.All, Times.Once);
        }
    }
}
