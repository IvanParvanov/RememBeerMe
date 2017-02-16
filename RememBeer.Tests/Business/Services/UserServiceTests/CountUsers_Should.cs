﻿using System.Collections.Generic;
using System.Linq;

using Moq;

using NUnit.Framework;

using RememBeer.Business.Services;
using RememBeer.Models.Factories;
using RememBeer.Models.Identity.Contracts;
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

            var signInManager = new Mock<IApplicationSignInManager>();
            var userManager = new Mock<IApplicationUserManager>();
            userManager.Setup(r => r.Users)
                       .Returns(queryableUsers);

            var modelFactory = new Mock<IModelFactory>();

            var service = new UserService(userManager.Object,
                                          signInManager.Object,
                                          modelFactory.Object);

            var result = service.CountUsers();

            Assert.AreEqual(expectedCount, result);
            userManager.VerifyGet(r => r.Users, Times.Once);
        }
    }
}
