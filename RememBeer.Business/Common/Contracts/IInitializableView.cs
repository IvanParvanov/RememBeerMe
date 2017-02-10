using System;

using WebFormsMvp;

namespace RememBeer.Business.Common.Contracts
{
    public interface IInitializableView<T> : IView<T> where T: class, new()
    {
        event EventHandler<System.EventArgs> OnInitialize;
    }
}
