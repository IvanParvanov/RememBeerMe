﻿using System;
using System.Collections.Generic;
using System.Linq;

using RememBeer.Business.Services.Contracts;
using RememBeer.Data.Repositories;
using RememBeer.Data.Repositories.Base;
using RememBeer.Models;
using RememBeer.Models.Contracts;

namespace RememBeer.Business.Services
{
    public class BreweryService : IBreweryService
    {
        private readonly IRepository<Brewery> breweryRepository;
        private readonly IRepository<Beer> beerRepository;

        public BreweryService(IRepository<Brewery> breweryRepository, IRepository<Beer> beerRepository)
        {
            if (breweryRepository == null)
            {
                throw new ArgumentNullException(nameof(breweryRepository));
            }

            if (beerRepository == null)
            {
                throw new ArgumentNullException(nameof(beerRepository));
            }

            this.beerRepository = beerRepository;
            this.breweryRepository = breweryRepository;
        }

        public IEnumerable<IBrewery> GetAll()
        {
            return this.breweryRepository.GetAll();
        }

        public IEnumerable<IBrewery> GetAll<T>(int skip, int pageSize, Func<IBrewery, T> order)
        {
            return this.breweryRepository.All
                       .OrderBy(order)
                       .Skip(skip)
                       .Take(pageSize)
                       .ToList();
        }

        public IEnumerable<IBrewery> Search(string pattern)
        {
            return this.breweryRepository.All
                       .Where(b => b.Country.Contains(pattern) || b.Name.Contains(pattern))
                       .ToList();
        }

        public IBrewery GetById(object id)
        {
            return this.breweryRepository.GetById(id);
        }

        public IDataModifiedResult UpdateBrewery(int id, string name, string country, string description)
        {
            var brewery = this.breweryRepository.GetById(id);
            brewery.Name = name;
            brewery.Country = country;
            brewery.Description = description;
            this.breweryRepository.Update(brewery);

            return this.breweryRepository.SaveChanges();
        }

        public IDataModifiedResult AddNewBeer(int breweryId, int beerTypeId, string name)
        {
            var beer = new Beer()
                       {
                           BreweryId = breweryId,
                           BeerTypeId = beerTypeId,
                           Name = name
                       };
            this.beerRepository.Add(beer);

            return this.beerRepository.SaveChanges();
        }
    }
}
