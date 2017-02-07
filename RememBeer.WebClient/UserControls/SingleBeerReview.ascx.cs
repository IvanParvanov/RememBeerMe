using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using RememBeer.Models.Contracts;

namespace RememBeer.WebClient.UserControls
{
    public partial class SingleBeerReview : System.Web.UI.UserControl
    {
        private IBeerReview beerReview;

        public bool IsEdit
        {
            get { return this.EditButton.Visible; }
            set { this.EditButton.Visible = value; }
        }

        public IBeerReview Review
        {
            get { return this.beerReview; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(this.beerReview));
                }

                this.beerReview = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }
    }
}
