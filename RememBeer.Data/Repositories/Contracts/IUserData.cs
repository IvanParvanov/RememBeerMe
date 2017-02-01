using RememBeer.Data.Repositories.Base;

namespace RememBeer.Data.Repositories.Contracts
{
    public interface IUserData
    {
        IGenericRepository<ApplicationUser> Users { get; set; }
    }
}