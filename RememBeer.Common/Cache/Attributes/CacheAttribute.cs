using System;

using Ninject;
using Ninject.Extensions.Interception;
using Ninject.Extensions.Interception.Attributes;
using Ninject.Extensions.Interception.Request;

using RememBeer.Common.Cache.Interceptors;

namespace RememBeer.Common.Cache.Attributes
{
    [AttributeUsage(AttributeTargets.Method)]
    public class CacheAttribute : InterceptAttribute
    {
        public CacheAttribute(int timeoutInMinutes)
        {
            this.TimeoutInMinutes = timeoutInMinutes;
        }

        public int TimeoutInMinutes { get; set; }

        public override IInterceptor CreateInterceptor(IProxyRequest request)
        {
            var interceptor = request.Kernel.Get<CacheInterceptor>();

            if (this.TimeoutInMinutes != 0)
            {
                interceptor.Timeout = TimeSpan.FromMinutes(this.TimeoutInMinutes);
            }

            interceptor.CacheKeyPrefix = request.Target.GetType().FullName;

            return interceptor;
        }
    }
}
