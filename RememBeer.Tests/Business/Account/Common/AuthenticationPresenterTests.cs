using System;

using Moq;

using NUnit.Framework;

using RememBeer.Business.Account.Common.Presenters;
using RememBeer.Business.Account.Confirm.Contracts;

namespace RememBeer.Tests.Business.Account.Common
{
    [TestFixture]
    public class AuthenticationPresenterTests
    {
        [Test]
        public void Ctor_ShouldThrowArgumentNullException_WhenArgumentsAreNull()
        {
            var mockedView = new Mock<IConfirmView>();
            Assert.Throws<ArgumentNullException>(() => new UserServicePresenter<IConfirmView>(null, mockedView.Object));
        }
    }
}
