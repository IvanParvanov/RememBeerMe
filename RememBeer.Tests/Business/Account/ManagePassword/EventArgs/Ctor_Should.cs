using Microsoft.Owin;

using Moq;

using NUnit.Framework;

using RememBeer.Business.Account.ManagePassword;

namespace RememBeer.Tests.Business.Account.ManagePassword.EventArgs
{
    [TestFixture]
    public class Ctor_Should
    {
        [Test]
        public void SetPropertiesCorrectly()
        {
            var current = "asd@abv.bg";
            var newPass = "password123";
            var userId = "897sad89&D*(&AS*(D7a(S*Dasdjkasdhasjkhasdk";
            var mockedContext = new Mock<IOwinContext>();

            var args = new ChangePasswordEventArgs(mockedContext.Object, current, newPass, userId);

            Assert.AreSame(mockedContext.Object, args.Context);
            Assert.AreSame(current, args.CurrentPassword);
            Assert.AreSame(newPass, args.NewPassword);
            Assert.AreEqual(userId, args.UserId);
        }
    }
}
