using System;
using System.Collections.Generic;
using System.Web.Http.Dependencies;

using Ninject.Syntax;

namespace Ninject.WebApi.DependencyResolver
{
    public class NinjectDependencyScope : IDependencyScope
    {
        private IResolutionRoot resolver;

        public NinjectDependencyScope(IResolutionRoot resolver)
        {
            this.resolver = resolver;
        }

        public object GetService(Type serviceType)
        {
            if (this.resolver == null)
                throw new ObjectDisposedException("this", "This scope has been disposed");

            return this.resolver.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            if (this.resolver == null)
                throw new ObjectDisposedException("this", "This scope has been disposed");

            return this.resolver.GetAll(serviceType);
        }

        public void Dispose()
        {
            var disposable = this.resolver as IDisposable;
            if (disposable != null)
                disposable.Dispose();

            this.resolver = null;
        }
    }

    public class NinjectDependencyResolver : NinjectDependencyScope, IDependencyResolver
    {
        private readonly IKernel kernel;

        public NinjectDependencyResolver(IKernel kernel)
            : base(kernel)
        {
            this.kernel = kernel;
        }

        public IDependencyScope BeginScope()
        {
            return new NinjectDependencyScope(this.kernel.BeginBlock());
        }
    }
}
