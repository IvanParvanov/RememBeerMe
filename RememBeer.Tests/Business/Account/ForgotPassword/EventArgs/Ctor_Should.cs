using Microsoft.Owin;

using Moq;

using NUnit.Framework;

using RememBeer.Business.Account.ForgotPassword;

namespace RememBeer.Tests.Business.Account.ForgotPassword.EventArgs
{
    [TestFixture]
    public class Ctor_Should
    {
        [Test]
        public void SetUpPropertiesCorrectly()
        {
            var mockedCtx = new Mock<IOwinContext>();
            var email = "asd@abv.bg";

            var args = new ForgotPasswordEventArgs(mockedCtx.Object, email);

            Assert.AreSame(mockedCtx.Object, args.Context);
            Assert.AreSame(email, args.Email);

        }
    }
}
