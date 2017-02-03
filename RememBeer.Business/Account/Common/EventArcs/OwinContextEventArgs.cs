using System;

using Microsoft.Owin;

using RememBeer.Business.Account.Common.EventArcs.Contracts;

namespace RememBeer.Business.Account.Common.EventArcs
{
    public abstract class OwinContextEventArgs : EventArgs, IOwinContextEventArgs
    {
        protected OwinContextEventArgs(IOwinContext context)
        {
            this.Context = context;
        }

        public  IOwinContext Context { get; }
    }
}
