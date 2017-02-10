﻿using RememBeer.Common.Identity.Contracts;
using RememBeer.Common.Identity.Models;
using RememBeer.Models.Contracts;
using RememBeer.Models.Dtos;

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

        public IBeerRank CreateBeerRank(decimal overallScore,
                                        decimal tasteScore,
                                        decimal lookScore,
                                        decimal smellScore,
                                        IBeer beer,
                                        decimal compositeScore,
                                        int totalReviews)
        {
            return new BeerRank(overallScore, tasteScore, lookScore, smellScore, beer, compositeScore, totalReviews);
        }
    }
}
