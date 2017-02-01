using Microsoft.AspNet.Identity.EntityFramework;

using RememBeer.Data.Repositories.Base;

namespace RememBeer.Data.Repositories.Contracts
{
    public interface IRolesData
    {
        IGenericRepository<IdentityRole> Roles { get; set; }

    }
}
