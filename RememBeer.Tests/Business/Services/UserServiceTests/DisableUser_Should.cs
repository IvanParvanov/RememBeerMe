﻿using System;
using System.Threading.Tasks;

using Microsoft.AspNet.Identity;

using Moq;

using NUnit.Framework;

using Ploeh.AutoFixture;

using RememBeer.Business.Services;
using RememBeer.Common.Identity.Contracts;
using RememBeer.Common.Identity.Models;
using RememBeer.Data.Repositories.Base;
using RememBeer.Models.Factories;
using RememBeer.Tests.Common;

namespace RememBeer.Tests.Business.Services.UserServiceTests
{
    public class DisableUser_Should : TestClassBase
    {
        [Test]
        public void CallUserManagerUpdateSecurityStampAsyncMethodOnceWithCorrectParams()
        {
            var expectedId = this.Fixture.Create<string>();
            var userManager = new Mock<IApplicationUserManager>();
            userManager.Setup(m => m.UpdateSecurityStampAsync(expectedId))
                       .Returns(Task.FromResult(IdentityResult.Failed()));

            var signInManager = new Mock<IApplicationSignInManager>();
            var repository = new Mock<IRepository<ApplicationUser>>();
            var modelFactory = new Mock<IModelFactory>();

            var service = new UserService(userManager.Object,
                                          signInManager.Object,
                                          repository.Object,
                                          modelFactory.Object);

            var result = service.DisableUser(expectedId);

            userManager.Verify(m => m.UpdateSecurityStampAsync(expectedId), Times.Once);
        }

        [Test]
        public void ReturnResultFrom_UserManagerUpdateSecurityStampAsyncMethod_WhenItReturnsFail()
        {
            var expectedResult = IdentityResult.Failed();
            var expectedId = this.Fixture.Create<string>();
            var userManager = new Mock<IApplicationUserManager>();
            userManager.Setup(m => m.UpdateSecurityStampAsync(It.IsAny<string>()))
                       .Returns(Task.FromResult(expectedResult));

            var signInManager = new Mock<IApplicationSignInManager>();
            var repository = new Mock<IRepository<ApplicationUser>>();
            var modelFactory = new Mock<IModelFactory>();

            var service = new UserService(userManager.Object,
                                          signInManager.Object,
                                          repository.Object,
                                          modelFactory.Object);

            var result = service.DisableUser(expectedId);

            Assert.AreSame(expectedResult, result);
        }

        [Test]
        public void Call_UserManagerSetLockoutEndDateAsyncMethodOnceWithCorrectparams_WhenTimeStampChangeIsSuccessfull()
        {
            var expectedResult = IdentityResult.Success;
            var expectedId = this.Fixture.Create<string>();
            var userManager = new Mock<IApplicationUserManager>();
            userManager.Setup(m => m.UpdateSecurityStampAsync(It.IsAny<string>()))
                       .Returns(Task.FromResult(expectedResult));

            var signInManager = new Mock<IApplicationSignInManager>();
            var repository = new Mock<IRepository<ApplicationUser>>();
            var modelFactory = new Mock<IModelFactory>();

            var service = new UserService(userManager.Object,
                                          signInManager.Object,
                                          repository.Object,
                                          modelFactory.Object);

            var result = service.DisableUser(expectedId);

            userManager.Verify(m => m.SetLockoutEndDateAsync(expectedId, DateTimeOffset.MaxValue), Times.Once);
        }

        [Test]
        public void
            ReturnResultFrom_UserManagerSetLockoutEndDateAsyncMethodOnceWithCorrectparams_WhenTimeStampChangeIsSuccessfull
            ()
        {
            var expectedResult = IdentityResult.Success;
            var expectedId = this.Fixture.Create<string>();
            var userManager = new Mock<IApplicationUserManager>();
            userManager.Setup(m => m.UpdateSecurityStampAsync(It.IsAny<string>()))
                       .Returns(Task.FromResult(expectedResult));
            userManager.Setup(m => m.SetLockoutEndDateAsync(It.IsAny<string>(), It.IsAny<DateTimeOffset>()))
                       .Returns(Task.FromResult(expectedResult));

            var signInManager = new Mock<IApplicationSignInManager>();
            var repository = new Mock<IRepository<ApplicationUser>>();
            var modelFactory = new Mock<IModelFactory>();

            var service = new UserService(userManager.Object,
                                          signInManager.Object,
                                          repository.Object,
                                          modelFactory.Object);

            var result = service.DisableUser(expectedId);

            Assert.AreSame(expectedResult, result);
        }
    }
}
