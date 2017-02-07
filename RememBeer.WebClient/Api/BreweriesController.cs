using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using Ninject;
using Ninject.Web.WebApi;

using RememBeer.Data.Repositories.Contracts;
using RememBeer.Models;

namespace RememBeer.WebClient.Api
{
    public class BreweriesController
    {
        public IBreweriesData Data { get; set; }

        public BreweriesController(IBreweriesData data)
        {
            this.Data = data;
        }

        // GET api/<controller>
        public IEnumerable<Brewery> Get()
        {
            return this.Data.Breweries;
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }
    }
}