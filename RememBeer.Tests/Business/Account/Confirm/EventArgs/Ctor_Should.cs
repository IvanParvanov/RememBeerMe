using Microsoft.Owin;

using Moq;

using NUnit.Framework;

using RememBeer.Business.Account.Confirm;

namespace RememBeer.Tests.Business.Account.Confirm.EventArgs
{
    [TestFixture]
    public class Ctor_Should
    {
        [Test]
        public void SetPropertiesCorrectly()
        {
            var code = "asd@abv.bg";
            var userId = "password123";
            var mockedContext = new Mock<IOwinContext>();

            var args = new ConfirmEventArgs(mockedContext.Object, userId, code);

            Assert.AreSame(mockedContext.Object, args.Context);
            Assert.AreSame(code, args.Code);
            Assert.AreSame(userId, args.UserId);
        }
    }
}
