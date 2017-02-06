using RememBeer.Common.Identity.Models;

namespace RememBeer.Models.Factories
{
    public interface IModelFactory
    {
        ApplicationUser CreateApplicationUser(string username, string email);
    }
}
