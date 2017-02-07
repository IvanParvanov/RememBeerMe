using System;
using System.ComponentModel.DataAnnotations;

using RememBeer.Common.Identity.Models;
using RememBeer.Models.Contracts;

namespace RememBeer.Models
{
    public class BeerReview : Identifiable, IBeerReview
    {
        public BeerReview()
        {
            this.IsPublic = true;
        }

        public int BeerId { get; set; }

        public virtual Beer Beer { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public int Overall { get; set; }

        public int Look { get; set; }

        public int Smell { get; set; }

        public int Taste { get; set; }

        [Required]
        public string Description { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime ModifiedAt { get; set; }

        public bool IsPublic { get; set; }

        public bool IsDeleted { get; set; }

        public string Place { get; set; }
    }
}
