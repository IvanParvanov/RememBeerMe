using System.ComponentModel.DataAnnotations;

using RememBeer.Models.Contracts;

namespace RememBeer.Models
{
    public class BeerType : Identifiable, IBeerType
    {
        [Required]
        public string Type { get; set; }
    }
}
