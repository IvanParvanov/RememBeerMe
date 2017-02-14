using Microsoft.AspNet.Identity;

using Moq;

using NUnit.Framework;

using Ploeh.AutoFixture;

using RememBeer.Business.Logic.Admin.ManageUsers;
using RememBeer.Business.Logic.Admin.ManageUsers.Contracts;
using RememBeer.Business.Logic.Common.EventArgs.Contracts;
using RememBeer.Business.Services.Contracts;
using RememBeer.Tests.Common;

namespace RememBeer.Tests.Business.Logic.Admin.ManageUsers.Presenter
{
    [TestFixture]
    public class OnViewMakeAdmin_Should : TestClassBase
    {
        [Test]
        public void Call_UserServiceMakeAdminMethodOnceWithCorrectParams()
        {
            var id = this.Fixture.Create<string>();

            var view = new Mock<IManageUsersView>();
            var userService = new Mock<IUserService>();
            userService.Setup(s => s.MakeAdmin(id))
                       .Returns(IdentityResult.Success);

            var args = new Mock<IIdentifiableEventArgs<string>>();
            args.Setup(a => a.Id)
                .Returns(id);

            var sut = new ManageUsersPresenter(userService.Object, view.Object);
            view.Raise(v => v.UserMakeAdmin += null, view.Object, args.Object);

            userService.Verify(s => s.MakeAdmin(id), Times.Once);
        }

        [Test]
        public void Set_ViewSuccessMessage_WhenResultSucceeds()
        {
            var id = this.Fixture.Create<string>();

            var view = new Mock<IManageUsersView>();
            var userService = new Mock<IUserService>();
            userService.Setup(s => s.MakeAdmin(id))
                       .Returns(IdentityResult.Success);

            var args = new Mock<IIdentifiableEventArgs<string>>();
            args.Setup(a => a.Id)
                .Returns(id);

            var sut = new ManageUsersPresenter(userService.Object, view.Object);
            view.Raise(v => v.UserMakeAdmin += null, view.Object, args.Object);

            view.VerifySet(v => v.SuccessMessageVisible = true);
            view.VerifySet(v => v.SuccessMessageText = It.IsAny<string>());
        }

        [Test]
        public void Set_ViewErrorMessage_WhenResultFails()
        {
            var id = this.Fixture.Create<string>();

            var view = new Mock<IManageUsersView>();
            var userService = new Mock<IUserService>();
            userService.Setup(s => s.MakeAdmin(id))
                       .Returns(IdentityResult.Failed());

            var args = new Mock<IIdentifiableEventArgs<string>>();
            args.Setup(a => a.Id)
                .Returns(id);

            var sut = new ManageUsersPresenter(userService.Object, view.Object);
            view.Raise(v => v.UserMakeAdmin += null, view.Object, args.Object);

            view.VerifySet(v => v.ErrorMessageVisible = true);
            view.VerifySet(v => v.ErrorMessageText = It.IsAny<string>());
        }
    }
}
