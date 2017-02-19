﻿using System.Threading.Tasks;

using Microsoft.AspNet.Identity;

using Moq;

using NUnit.Framework;

using Ploeh.AutoFixture;

using RememBeer.Business.Services;
using RememBeer.Models.Factories;
using RememBeer.Models.Identity.Contracts;
using RememBeer.Tests.Common;

using Constants = RememBeer.Common.Constants.Constants;

namespace RememBeer.Tests.Business.Services.UserServiceTests
{
    [TestFixture]
    internal class MakeAdmin_Should : TestClassBase
    {
        [Test]
        public void Call_UserManagerAddToRoleAsyncMethodOnceWithCorrectParams()
        {
            var expectedId = this.Fixture.Create<string>();
            var userManager = new Mock<IApplicationUserManager>();
            userManager.Setup(m => m.AddToRoleAsync(expectedId, Constants.AdminRole))
                       .Returns(Task.FromResult(IdentityResult.Failed()));

            var signInManager = new Mock<IApplicationSignInManager>();
            var modelFactory = new Mock<IModelFactory>();

            var service = new UserService(userManager.Object,
                                          signInManager.Object,
                                          modelFactory.Object);

            var result = service.MakeAdmin(expectedId);

            userManager.Verify(m => m.AddToRoleAsync(expectedId, Constants.AdminRole), Times.Once);
        }

        [Test]
        public void ReturnResultFrom_UserManagerAddToRoleAsyncMethod()
        {
            var expectedResult = IdentityResult.Failed();
            var expectedId = this.Fixture.Create<string>();
            var userManager = new Mock<IApplicationUserManager>();
            userManager.Setup(m => m.AddToRoleAsync(expectedId, Constants.AdminRole))
                       .Returns(Task.FromResult(expectedResult));

            var signInManager = new Mock<IApplicationSignInManager>();
            var modelFactory = new Mock<IModelFactory>();

            var service = new UserService(userManager.Object,
                                          signInManager.Object,
                                          modelFactory.Object);

            var result = service.MakeAdmin(expectedId);

            Assert.AreSame(expectedResult, result);
        }
    }
}
