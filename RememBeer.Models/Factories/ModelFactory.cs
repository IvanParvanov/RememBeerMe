using RememBeer.Common.Identity.Models;

namespace RememBeer.Models.Factories
{
    public class ModelFactory : IModelFactory
    {
        public ApplicationUser CreateApplicationUser(string username, string email)
        {
            return new ApplicationUser()
                   {
                       UserName = username,
                       Email = email
                   };
        }
    }
}
