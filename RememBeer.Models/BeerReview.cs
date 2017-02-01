using System;

namespace RememBeer.Models
{
    public class BeerReview : Identifiable
    {
        public virtual Beer Beer { get; set; }

        //public virtual ApplicationUser User { get; set; }

        public int Overall { get; set; }

        public int Look { get; set; }

        public int Smell { get; set; }

        public int Taste { get; set; }

        public int MouthFeel { get; set; }

        public string Description { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime ModifiedAt { get; set; }

        public bool IsPublic { get; set; }

        public string Place { get; set; }
    }
}
