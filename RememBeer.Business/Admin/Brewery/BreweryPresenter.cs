using RememBeer.Business.Admin.Common;
using RememBeer.Business.Common.EventArgs.Contracts;
using RememBeer.Data.Services.Contracts;

namespace RememBeer.Business.Admin.Brewery
{
    public class BreweryPresenter : BreweryServicePresenter<ISingleBreweryView>
    {
        public BreweryPresenter(IBreweryService breweryService, ISingleBreweryView view)
            : base(breweryService, view)
        {
            this.View.Initialized += this.OnViewInitialized;
        }

        private void OnViewInitialized(object sender, IIdentifiableEventArgs<string> e)
        {
            var id = e.Id;
            int intId;
            var isValidId = int.TryParse(id, out intId);

            if (isValidId)
            {
                var brewery = this.BreweryService.GetById(intId);
                if (brewery == null)
                {
                    this.ShowNotFound();
                }
                else
                {
                    this.View.Model.Brewery = brewery;
                }
            }
            else
            {
                this.ShowNotFound();
            }
        }

        private void ShowNotFound()
        {
            this.View.ErrorMessageText = "Brewery not found!";
            this.View.ErrorMessageVisible = true;
        }
    }
}
