using RememBeer.Business.Common.EventArgs.Contracts;

namespace RememBeer.Business.Common.EventArgs
{
    public class SearchEventArgs : ISearchEventArgs
    {
        public SearchEventArgs(string pattern)
        {
            this.Pattern = pattern;
        }

        public string Pattern { get; }
    }
}
