using System.Linq;

using RememBeer.Data.Repositories.Base;

namespace RememBeer.Data.Repositories.Contracts
{
    public interface IUserData
    {
        IQueryable<ApplicationUser> Users { get; }
    }
}