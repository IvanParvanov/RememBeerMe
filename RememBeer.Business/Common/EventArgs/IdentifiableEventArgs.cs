using RememBeer.Business.Common.EventArgs.Contracts;

namespace RememBeer.Business.Common.EventArgs
{
    public class IdentifiableEventArgs<T> : IIdentifiableEventArgs<T>
    {
        public IdentifiableEventArgs(T id)
        {
            this.Id = id;
        }

        public T Id { get; set; }
    }
}
