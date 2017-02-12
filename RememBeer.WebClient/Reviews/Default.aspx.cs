﻿using System;

using RememBeer.Business.Common.EventArgs.Contracts;
using RememBeer.Business.Reviews.Common.ViewModels;
using RememBeer.Business.Reviews.Default;
using RememBeer.Business.Reviews.Default.Contracts;
using RememBeer.WebClient.BasePages;

using WebFormsMvp;

namespace RememBeer.WebClient.Reviews
{
    [PresenterBinding(typeof(DefaultPresenter))]
    public partial class Default : BaseMvpPage<BeerReviewViewModel>, IReviewDetailsView
    {
        public bool NotFoundVisible
        {
            get
            {
                return this.NotFound.Visible;
            }

            set
            {
                if (value)
                {
                    this.ReviewPlaceholder.Controls.RemoveAt(0);
                }

                this.NotFound.Visible = value;
            }
        }

        public event EventHandler<IIdentifiableEventArgs<int>> OnInitialise;

        protected void Page_Load(object sender, EventArgs e)
        {
            var id = -1;
            var strId = this.Request.QueryString["id"];
            var idIsValid = int.TryParse(strId, out id);
            if (idIsValid)
            {
                var args = this.EventArgsFactory.CreateIdentifiableEventArgs(id);
                this.OnInitialise?.Invoke(this, args);
            }
            else
            {
                this.NotFoundVisible = true;
            }
        }
    }
}