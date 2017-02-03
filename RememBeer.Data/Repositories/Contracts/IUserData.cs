using System.Linq;

using RememBeer.Data.Identity;
using RememBeer.Data.Identity.Models;
using RememBeer.Data.Repositories.Base;

namespace RememBeer.Data.Repositories.Contracts
{
    public interface IUserData
    {
        IQueryable<ApplicationUser> Users { get; }
    }
}