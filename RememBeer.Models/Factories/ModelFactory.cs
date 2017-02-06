using RememBeer.Common.Identity.Contracts;
using RememBeer.Common.Identity.Models;

namespace RememBeer.Models.Factories
{
    public class ModelFactory : IModelFactory
    {
        public IApplicationUser CreateApplicationUser(string username, string email)
        {
            return new ApplicationUser()
                   {
                       UserName = username,
                       Email = email
                   };
        }
    }
}
