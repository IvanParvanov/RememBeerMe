using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

using RememBeer.Common.Identity.Contracts;

namespace RememBeer.Business.Services.Contracts
{
    public interface IUserService
    {
        IdentityResult RegisterUser(string username, string email, string password);

        IdentityResult ChangePassword(string userId, string currentPassword, string newPassword);

        IdentityResult ConfirmEmail(string userId, string code);

        IApplicationUser FindByName(string name);

        bool IsEmailConfirmed(string userId);

        SignInStatus PasswordSignIn(string email, string password, bool isPersistent);

        IEnumerable<IApplicationUser> PaginatedUsers(int currentPage, int pageSize, out int total, string searchPattern = null);

        int CountUsers();

        IdentityResult DisableUser(string userId);

        IdentityResult EnableUser(string userId);

        IdentityResult RemoveAdmin(string userId);

        IdentityResult MakeAdmin(string userId);
    }
}
