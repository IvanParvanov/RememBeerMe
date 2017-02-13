using RememBeer.Common.Identity.Contracts;

namespace RememBeer.Models.Factories
{
    public interface IModelFactory : IBeerRankFactory
    {
        IApplicationUser CreateApplicationUser(string username, string email);
    }
}
