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

            var args = new ConfirmEventArgs(userId, code);

            Assert.AreSame(code, args.Code);
            Assert.AreSame(userId, args.UserId);
        }
    }
}
