using System.Linq;

using RememBeer.Data.Identity.Models;

namespace RememBeer.Data.Repositories.Contracts
{
    public interface IUserData
    {
        IQueryable<ApplicationUser> Users { get; }
    }
}