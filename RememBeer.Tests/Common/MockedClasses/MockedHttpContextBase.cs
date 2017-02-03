using System.Web;

namespace RememBeer.Tests.Common.MockedClasses
{
    public class MockedHttpContextBase : HttpContextBase
    {
        private readonly HttpResponseBase response;
        private readonly HttpRequestBase request;

        public MockedHttpContextBase()
        {
            this.response = new MockedHttpResponse();
            this.request = new MockedHttpRequest();
        }

        public MockedHttpContextBase(MockedHttpResponse response)
        {
            this.response = response;
            this.request = new MockedHttpRequest();
        }

        //public MockedHttpContextBase(MockedHttpRequest request)
        //{
        //    this.response = new MockedHttpResponse();
        //    this.request = request;
        //}

        //public MockedHttpContextBase(HttpResponseBase response, HttpRequestBase request)
        //{
        //    this.response = response;
        //    this.request = request;
        //}

        public override HttpResponseBase Response => this.response;

        public override HttpRequestBase Request => this.request;
    }
}
