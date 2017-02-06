﻿using System;

using RememBeer.Common.Identity.Contracts;
using RememBeer.Common.Identity.Models;

namespace RememBeer.Models.Contracts
{
    public interface IBeerReview
    {
        int BeerId { get; set; }

        Beer Beer { get; set; }

        int UserId { get; set; }

        User User { get; set; }

        int Overall { get; set; }

        int Look { get; set; }

        int Smell { get; set; }

        int Taste { get; set; }

        string Description { get; set; }

        DateTime CreatedAt { get; set; }

        DateTime ModifiedAt { get; set; }

        bool IsPublic { get; set; }

        string Place { get; set; }
    }
}