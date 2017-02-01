using System.Linq;

using Microsoft.AspNet.Identity.EntityFramework;

namespace RememBeer.Data.Repositories.Contracts
{
    public interface IRolesData
    {
        IQueryable<IdentityRole> Roles { get; }

    }
}
