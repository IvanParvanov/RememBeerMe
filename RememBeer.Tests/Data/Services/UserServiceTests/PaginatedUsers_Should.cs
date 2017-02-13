using System;
using System.Collections.Generic;
using System.Linq;

using Moq;

using NUnit.Framework;

using Ploeh.AutoFixture;

using RememBeer.Common.Identity.Contracts;
using RememBeer.Common.Identity.Models;
using RememBeer.Data.Repositories.Base;
using RememBeer.Data.Services;
using RememBeer.Models.Factories;
using RememBeer.Tests.Business.Mocks;
using RememBeer.Tests.Common;

namespace RememBeer.Tests.Data.Services.UserServiceTests
{
    [TestFixture]
    public class PaginatedUsers_Should : TestClassBase
    {
        [TestCase(2, 4, 15)]
        [TestCase(0, 4, 15)]
        [TestCase(4, 4, 20)]
        [TestCase(0, 10, 15)]
        public void ReturnCorrectPartOfTheCollectionInOrder(int currentPage, int pageSize, int totalCount)
        {
            var usernameComparer = Comparer<ApplicationUser>.Create((a, b) => string.Compare(a.UserName, b.UserName, StringComparison.Ordinal));
            var users = new List<MockedApplicationUser>();
            for (var i = 0; i < totalCount; i++)
            {
                users.Add(new MockedApplicationUser()
                          {
                              UserName = this.Fixture.Create<string>()
                          });
            }

            var queryableUsers = users.AsQueryable();

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

            var result = service.PaginatedUsers(currentPage, pageSize);
            var actualUsers = result as IApplicationUser[] ?? result.ToArray();
            var actualCount = actualUsers.Count();

            Assert.AreEqual(pageSize, actualCount);
            CollectionAssert.IsOrdered(actualUsers, usernameComparer);
        }
    }
}
