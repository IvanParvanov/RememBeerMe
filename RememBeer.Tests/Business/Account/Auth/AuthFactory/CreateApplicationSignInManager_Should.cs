using System;

using Microsoft.Owin;

using Moq;

using NUnit.Framework;

using RememBeer.Common.Identity.Contracts;

namespace RememBeer.Tests.Business.Account.Auth.AuthFactory
{
    [TestFixture]
    public class CreateApplicationSignInManager_Should
    {
        [Test]
        public void ThrowIfArgumentIsNull()
        {
            var authFactory = new RememBeer.Business.Account.Auth.AuthProvider();

            Assert.Throws<ArgumentNullException>(() => authFactory.CreateApplicationUserManager(null));
        }

        [Test]
        public void ReturnContextsUserManager()
        {
            var mockedCtx = new Mock<IOwinContext>();
            var mockedManager = new Mock<IApplicationSignInManager>();
            mockedCtx.Setup(c => c.Get<IApplicationSignInManager>(It.IsAny<string>()))
                     .Returns(mockedManager.Object);

            var authFactory = new RememBeer.Business.Account.Auth.AuthProvider();
            var result = authFactory.CreateApplicationSignInManager(mockedCtx.Object);

            Assert.AreSame(mockedManager.Object, result);
        }
    }
}
