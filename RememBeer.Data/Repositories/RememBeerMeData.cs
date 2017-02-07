using System.Linq;

using Microsoft.AspNet.Identity.EntityFramework;

using RememBeer.Common.Identity.Models;
using RememBeer.Data.Repositories.Base;
using RememBeer.Data.Repositories.Contracts;
using RememBeer.Models;

namespace RememBeer.Data.Repositories
{
    public class RememBeerMeData : IRememBeerMeData
    {
        private readonly IRepository<ApplicationUser> users;
        private readonly IRepository<IdentityRole> roles;
        private readonly IRepository<Beer> beers;
        private readonly IRepository<BeerReview> beerReviews;
        private readonly IRepository<BeerType> beerTypes;
        private readonly IRepository<Brewery> breweries;

        public RememBeerMeData(
            IRepository<ApplicationUser> users,
            IRepository<IdentityRole> roles,
            IRepository<Beer> beers,
            IRepository<BeerReview> beerReviews,
            IRepository<BeerType> beerTypes,
            IRepository<Brewery> breweries)
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

        public IRepository<BeerReview> BeerReviews => this.beerReviews;

        public IQueryable<BeerType> BeerTypes => this.beerTypes.All;

        public IQueryable<Brewery> Breweries => this.breweries.All;
    }
}
