using System;

using Microsoft.Owin;

using Moq;

using NUnit.Framework;

using RememBeer.Models.Identity.Contracts;

namespace RememBeer.Tests.Business.Logic.Account.Auth.AuthProvider
{
    [TestFixture]
    public class CreateApplicationUserManager_Should
    {
        [Test]
        public void ThrowIfArgumentIsNull()
        {
            var authFactory = new RememBeer.Business.Logic.Account.Auth.AuthProvider();

            Assert.Throws<ArgumentNullException>(() => authFactory.CreateApplicationUserManager(null));
        }

        [Test]
        public void ReturnContextsUserManager()
        {
            var mockedCtx = new Mock<IOwinContext>();
            var mockedManager = new Mock<IApplicationUserManager>();
            mockedCtx.Setup(c => c.Get<IApplicationUserManager>(It.IsAny<string>()))
                     .Returns(mockedManager.Object);

            var authFactory = new RememBeer.Business.Logic.Account.Auth.AuthProvider();
            var result = authFactory.CreateApplicationUserManager(mockedCtx.Object);

            Assert.AreSame(mockedManager.Object, result);
        }
    }
}
