using System.ComponentModel.DataAnnotations;

using RememBeer.Models.Contracts;

namespace RememBeer.Models
{
    public class BeerType : Identifiable, IBeerType
    {
        [Required]
        [MaxLength(512)]
        public string Type { get; set; }
    }
}
