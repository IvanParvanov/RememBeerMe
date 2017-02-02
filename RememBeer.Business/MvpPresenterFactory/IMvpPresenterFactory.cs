using System;

using WebFormsMvp;

namespace RememBeer.Business.MvpPresenter
{
    public interface IMvpPresenterFactory
    {
        IPresenter GetPresenter(Type presenterType, IView viewInstance);
    }
}
