namespace RememBeer.Business.Common.EventArgs.Contracts
{
    public interface IIdentifiableEventArgs<T>
    {
        T Id { get; set; }
    }
}
