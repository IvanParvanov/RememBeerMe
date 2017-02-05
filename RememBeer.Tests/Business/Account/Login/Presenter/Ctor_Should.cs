using System;

using Moq;

using NUnit.Framework;

using RememBeer.Business.Account.Auth;
using RememBeer.Business.Account.Login;
using RememBeer.Business.Account.Login.Contracts;

namespace RememBeer.Tests.Business.Account.Login.Presenter
{
    [TestFixture]
    public class Ctor_Should
    {
        [Test]
        public void ThrowArgumentNullException_WhenHelperIsNull()
        {
            var mockedView = new Mock<ILoginView>();
            var mockedAuthFactory = new Mock<IAuthFactory>();

            Assert.Throws<ArgumentNullException>(() => new LoginPresenter(mockedAuthFactory.Object, null, mockedView.Object));
        }
    }
}
