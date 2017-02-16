using RememBeer.Models.Contracts;

namespace RememBeer.Models.Factories
{
    public interface IModelFactory : IBeerRankFactory
    {
        IApplicationUser CreateApplicationUser(string username, string email);
    }
}
