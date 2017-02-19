using System.Web;

namespace RememBeer.Tests.Common.MockedClasses
{
    public class MockedHttpResponse : HttpResponseBase
    {
        public string RedirectUrl { get; private set; }

        public override void Redirect(string url)
        {
            this.RedirectUrl = url;
        }

        public override void Redirect(string url, bool endResponse)
        {
            this.RedirectUrl = url;
        }
    }
}
