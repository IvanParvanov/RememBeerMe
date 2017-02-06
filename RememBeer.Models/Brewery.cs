using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using RememBeer.Models.Contracts;

namespace RememBeer.Models
{
    public class Brewery : Identifiable, IBrewery
    {
        private ICollection<Beer> beers;

        public Brewery()
        {
            this.beers = new HashSet<Beer>();
        }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Country { get; set; }

        public virtual ICollection<Beer> Beers
        {
            get
            {
                return this.beers;
            }
            set
            {
                this.beers = value;
            }
        }
    }
}
