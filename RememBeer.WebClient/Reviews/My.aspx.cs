using System;
using System.Web.UI.WebControls;

using RememBeer.Business.Reviews.My;
using RememBeer.Business.Reviews.My.Contracts;
using RememBeer.WebClient.BasePages;

using WebFormsMvp;

namespace RememBeer.WebClient.Reviews
{
    [PresenterBinding(typeof(MyReviewsPresenter))]
    public partial class My : BaseMvpPage<ReviewsViewModel>, IMyReviewsView
    {
        public event EventHandler<EventArgs> OnInitialise;
         
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.OnInitialise?.Invoke(this, EventArgs.Empty);
                this.ReviewsListView.DataSource = this.Model.Reviews;
                this.ReviewsListView.DataBind();
            }
        }

        protected void ReviewsListView_OnItemEditing(object sender, ListViewEditEventArgs e)
        {
            this.ReviewsListView.EditIndex = e.NewEditIndex;
            //ReviewsListView.DataSource = this.Model.Reviews;
            //ReviewsListView.DataBind();
        }
    }
}