using System.Collections.Generic;

using RememBeer.Common.Identity.Contracts;

namespace RememBeer.Business.Admin.ManageUsers
{
    public class ManageUsersViewModel
    {
        public IEnumerable<IApplicationUser> Users { get; set; }
    }
}
