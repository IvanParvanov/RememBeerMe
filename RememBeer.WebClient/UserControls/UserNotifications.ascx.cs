using System;
using System.Web.UI;

namespace RememBeer.WebClient.UserControls
{
    public partial class UserNotifications : UserControl
    {
        public bool SuccessMessageVisible
        {
            get { return this.SuccessMessagePlaceholder.Visible; }
            set { this.SuccessMessagePlaceholder.Visible = value; }
        }

        public string SuccessMessageText
        {
            get { return this.SuccessMessage.Text; }
            set { this.SuccessMessage.Text = value; }
        }

        public bool WarningMessageVisible
        {
            get { return this.WarningMessagePlaceholder.Visible; }
            set { this.WarningMessagePlaceholder.Visible = value; }
        }

        public string WarningMessageText
        {
            get { return this.WarningMessage.Text; }
            set { this.WarningMessage.Text = value; }
        }

        public bool ErrorMessageVisible
        {
            get { return this.ErrorMessagePlaceholder.Visible; }
            set { this.ErrorMessagePlaceholder.Visible = value; }
        }

        public string ErrorMessageText
        {
            get { return this.ErrorMessage.Text; }
            set { this.ErrorMessage.Text = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }
    }
}