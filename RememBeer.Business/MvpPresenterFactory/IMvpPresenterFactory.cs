using System;

using WebFormsMvp;

namespace RememBeer.Business.MvpPresenterFactory
{
    public interface IMvpPresenterFactory
    {
        IPresenter GetPresenter(Type presenterType, IView viewInstance);
    }
}
