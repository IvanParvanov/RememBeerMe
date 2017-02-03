using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Owin;

using Moq;

using NUnit.Framework;

using RememBeer.Data.Identity.Contracts;

namespace RememBeer.Tests.Business.Account.Auth.AuthFactory
{
    [TestFixture]
    public class CreateApplicationUserManager_Should
    {
        [Test]
        public void ThrowIfArgumentIsNull()
        {
            var authFactory = new RememBeer.Business.Account.Auth.AuthFactory();

            Assert.Throws<ArgumentNullException>(() => authFactory.CreateApplicationUserManager(null));
        }

        [Test]
        public void ReturnContextsUserManager()
        {
            var mockedCtx = new Mock<IOwinContext>();
            var mockedManager = new Mock<IApplicationUserManager>();
            mockedCtx.Setup(c => c.Get<IApplicationUserManager>(It.IsAny<string>()))
                     .Returns(mockedManager.Object);

            var authFactory = new RememBeer.Business.Account.Auth.AuthFactory();
            var result = authFactory.CreateApplicationUserManager(mockedCtx.Object);

            Assert.AreSame(mockedManager.Object, result);
        }
    }
}
