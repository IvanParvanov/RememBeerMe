using RememBeer.Business.Common.EventArgs.Contracts;

namespace RememBeer.Business.Admin.Brewery.Contracts
{
    public interface IBreweryUpdateEventArgs : IIdentifiableEventArgs<int>
    {
        string Description { get; set; }

        string Name { get; set; }

        string Country { get; set; }
    }
}
