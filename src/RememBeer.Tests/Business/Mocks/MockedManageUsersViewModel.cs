using System.Collections.Generic;

using RememBeer.Business.Logic.Admin.ManageUsers;
using RememBeer.Models.Contracts;

namespace RememBeer.Tests.Business.Mocks
{
    public class MockedManageUsersViewModel : ManageUsersViewModel
    {
        public override IEnumerable<IApplicationUser> Users { get; set; }
    }
}
