using System;

using Microsoft.Owin;

using NUnit.Framework;

using RememBeer.Tests.Common.MockedClasses;

namespace RememBeer.Tests.Business.Account.Auth.AuthFactory
{
    public class CreateOwinContext_Should
    {
        [Test]
        public void ThrowIfArgumentIsNull()
        {
            var authFactory = new RememBeer.Business.Account.Auth.AuthProvider();

            Assert.Throws<ArgumentNullException>(() => authFactory.CreateOwinContext(null));
        }

        [Test]
        public void ReturnOwinContext()
        {
            var mockedHttpContextBase = new MockedHttpContextBase();

            var authFactory = new RememBeer.Business.Account.Auth.AuthProvider();
            var result = authFactory.CreateOwinContext(mockedHttpContextBase);

            Assert.IsNotNull(result);
            Assert.IsInstanceOf(typeof(IOwinContext), result);
        }
    }
}
