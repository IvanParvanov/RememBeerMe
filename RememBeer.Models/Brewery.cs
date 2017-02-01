using System.Collections.Generic;

namespace RememBeer.Models
{
    public class Brewery : Identifiable
    {
        private ICollection<Beer> beers;

        public Brewery()
        {
            this.beers = new HashSet<Beer>();
        }

        public string Name { get; set; }

        public string Description { get; set; }

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
