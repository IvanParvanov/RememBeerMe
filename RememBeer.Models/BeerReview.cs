using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        [Required]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public int Overall { get; set; }

        public int Look { get; set; }

        public int Smell { get; set; }

        public int Taste { get; set; }

        [Required]
        [MaxLength(2048)]
        public string Description { get; set; }

        [Required, DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreatedAt { get; set; }

        [Required, DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime ModifiedAt { get; set; }

        public bool IsPublic { get; set; }

        public bool IsDeleted { get; set; }

        [MaxLength(512)]
        [Required]
        public string Place { get; set; }
    }
}
