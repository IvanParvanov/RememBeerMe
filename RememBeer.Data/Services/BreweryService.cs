using System;
using System.Collections.Generic;
using System.Linq;

using RememBeer.Data.Repositories.Base;
using RememBeer.Data.Services.Contracts;
using RememBeer.Models;
using RememBeer.Models.Contracts;

namespace RememBeer.Data.Services
{
    public class BreweryService : IBreweryService
    {
        private readonly IRepository<Brewery> repository;

        public BreweryService(IRepository<Brewery> repository)
        {
            if (repository == null)
            {
                throw new ArgumentNullException(nameof(repository));
            }

            this.repository = repository;
        }

        public IEnumerable<IBrewery> GetAll()
        {
            return this.repository.GetAll();
        }

        public IEnumerable<IBrewery> GetAll<T>(int skip, int pageSize, Func<IBrewery, T> order)
        {
            return this.repository.All
                       .OrderBy(order)
                       .Skip(skip)
                       .Take(pageSize)
                       .ToList();
        }

        public IEnumerable<IBrewery> Search(string pattern)
        {
            return this.repository.All
                       .Where(b => b.Country.Contains(pattern) || b.Name.Contains(pattern))
                       .ToList();
        }

        public IBrewery GetById(object id)
        {
            return this.repository.GetById(id);
        }

        public IBrewery UpdateBrewery(int id, string name, string country, string description)
        {
            var brewery = this.repository.GetById(id);
            brewery.Name = name;
            brewery.Country = country;
            brewery.Description = description;
            this.repository.Update(brewery);
            this.repository.SaveChanges();

            return brewery;
        }
    }
}
