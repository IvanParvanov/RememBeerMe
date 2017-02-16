namespace RememBeer.Models.Dtos
{
    public interface IBreweryRank
    {
        decimal AveragePerBeer { get; set; }

        int TotalBeersCount { get; set; }

        string Name { get; set; }
    }

    public class BreweryRank : IBreweryRank
    {
        public decimal AveragePerBeer { get; set; }

        public int TotalBeersCount { get; set; }

        public string Name { get; set; }
    }
}
