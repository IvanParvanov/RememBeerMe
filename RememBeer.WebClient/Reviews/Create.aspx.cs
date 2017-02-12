﻿using System;

using Microsoft.AspNet.Identity;

using RememBeer.Business.Account.Common.ViewModels;
using RememBeer.Business.Reviews.Create;
using RememBeer.Business.Reviews.Create.Contracts;
using RememBeer.Business.Reviews.My.Contracts;
using RememBeer.Models;
using RememBeer.WebClient.BasePages;

using WebFormsMvp;

namespace RememBeer.WebClient.Reviews
{
    [PresenterBinding(typeof(CreateReviewPresenter))]
    public partial class Create : BaseMvpPage<StatelessViewModel>, ICreateReviewView
    {
        public event EventHandler<IBeerReviewInfoEventArgs> OnCreateReview;

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void InsertButton_OnClick(object sender, EventArgs e)
        {
            var userId = this.User.Identity.GetUserId();
            var review = new BeerReview()
                         {
                             BeerId = int.Parse(this.HiddenBeerId.Value),
                             Place = this.TbPlace.Text,
                             Description = this.TbDescription.Text,
                             Overall = int.Parse(this.BeerRatingSelect5.SelectedValue),
                             Taste = int.Parse(this.BeerRatingSelect6.SelectedValue),
                             Look = int.Parse(this.BeerRatingSelect7.SelectedValue),
                             Smell = int.Parse(this.BeerRatingSelect8.SelectedValue),
                             UserId = userId
                         };

            var uploadControl = this.ImageUpload;
            byte[] image = null;
            if (uploadControl.HasFile)
            {
                var a = uploadControl;
                image = a.FileBytes;
            }

            var args = this.EventArgsFactory.CreateBeerReviewInfoEventArgs(review, image);
            this.OnCreateReview?.Invoke(this, args);
        }
    }
}