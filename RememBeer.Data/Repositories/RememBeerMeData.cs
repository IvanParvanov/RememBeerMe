using Microsoft.AspNet.Identity.EntityFramework;

using RememBeer.Data.Repositories.Base;
using RememBeer.Data.Repositories.Contracts;
using RememBeer.Models;

namespace RememBeer.Data.Repositories
{
    public class RememBeerMeData : IRememBeerMeData
    {
        private IGenericRepository<ApplicationUser> users;
        private IGenericRepository<IdentityRole> roles;
        private IGenericRepository<Beer> beers;
        private IGenericRepository<BeerReview> beerReviews;
        private IGenericRepository<BeerType> beerTypes;
        private IGenericRepository<Brewery> breweries;

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

        public IGenericRepository<IdentityRole> Roles
        {
            get { return this.roles; }
            set { this.roles = value; }
        }

        public IGenericRepository<ApplicationUser> Users
        {
            get { return this.users; }
            set { this.users = value; }
        }

        public IGenericRepository<Beer> Beers
        {
            get { return this.beers; }
            set { this.beers = value; }
        }

        public IGenericRepository<BeerReview> BeerReviews
        {
            get { return this.beerReviews; }
            set { this.beerReviews = value; }
        }

        public IGenericRepository<BeerType> BeerTypes
        {
            get { return this.beerTypes; }
            set { this.beerTypes = value; }
        }

        public IGenericRepository<Brewery> Breweries
        {
            get { return this.breweries; }
            set { this.breweries = value; }
        }
    }
}
