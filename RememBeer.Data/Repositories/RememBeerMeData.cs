using System.Linq;

using Microsoft.AspNet.Identity.EntityFramework;

using RememBeer.Data.Repositories.Base;
using RememBeer.Data.Repositories.Contracts;
using RememBeer.Models;

namespace RememBeer.Data.Repositories
{
    public class RememBeerMeData : IRememBeerMeData
    {
        private readonly IGenericRepository<ApplicationUser> users;
        private readonly IGenericRepository<IdentityRole> roles;
        private readonly IGenericRepository<Beer> beers;
        private readonly IGenericRepository<BeerReview> beerReviews;
        private readonly IGenericRepository<BeerType> beerTypes;
        private readonly IGenericRepository<Brewery> breweries;

        public RememBeerMeData(
            IGenericRepository<ApplicationUser> users,
            IGenericRepository<IdentityRole> roles,
            IGenericRepository<Beer> beers,
            IGenericRepository<BeerReview> beerReviews,
            IGenericRepository<BeerType> beerTypes,
            IGenericRepository<Brewery> breweries)
        {
            this.users = users;
            this.roles = roles;
            this.beers = beers;
            this.beerReviews = beerReviews;
            this.beerTypes = beerTypes;
            this.breweries = breweries;
        }

        public IQueryable<IdentityRole> Roles => this.roles.All;

        public IQueryable<ApplicationUser> Users => this.users.All;

        public IQueryable<Beer> Beers => this.beers.All;

        public IQueryable<BeerReview> BeerReviews => this.beerReviews.All;

        public IQueryable<BeerType> BeerTypes => this.beerTypes.All;

        public IQueryable<Brewery> Breweries => this.breweries.All;
    }
}
