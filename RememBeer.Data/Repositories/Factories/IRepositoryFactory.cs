using RememBeer.Data.Repositories.Contracts;

namespace RememBeer.Data.Repositories.Factories
{
    public interface IRepositoryFactory
    {
        IBeersData CreateBeerData();

        IBeerReviewsData CreateBeerReviewsData();

        IBeerTypesData CreateBeerTypesData();

        IBreweriesData CreateBreweriesData();

        IUserData CreateUserData();

        IRolesData CreateRolesData();

        IRememBeerMeData CreateRememBeerMeData();
    }
}
