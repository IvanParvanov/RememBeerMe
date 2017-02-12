﻿using System;
using System.Collections.Generic;

using RememBeer.Models;
using RememBeer.Models.Contracts;

namespace RememBeer.Data.Services.Contracts
{
    public interface IBreweryService
    {
        IEnumerable<IBrewery> GetAll();

        IEnumerable<IBrewery> GetAll<T>(int skip, int pageSize, Func<Brewery, T> order);

        IEnumerable<IBrewery> Search(string pattern);
    }
}