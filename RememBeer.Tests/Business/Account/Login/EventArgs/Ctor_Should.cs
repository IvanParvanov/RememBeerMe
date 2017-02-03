using Microsoft.Owin;

using Moq;

using NUnit.Framework;

using RememBeer.Business.Account.Login;

namespace RememBeer.Tests.Business.Account.Login.EventArgs
{
    [TestFixture]
    public class Ctor_Should
    {
        [Test]
        public void SetPropertiesCorrectly()
        {
            var email = "asd@abv.bg";
            var password = "password123";
            var rememberMe = false;
            var mockedContext = new Mock<IOwinContext>();

            var args = new LoginEventArgs(mockedContext.Object, email, password, rememberMe);

            Assert.AreSame(mockedContext.Object, args.Context);
            Assert.AreSame(email, args.Email);
            Assert.AreSame(password, args.Password);
            Assert.AreEqual(rememberMe, args.RememberMe);
        }
    }
}
