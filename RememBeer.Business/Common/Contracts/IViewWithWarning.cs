namespace RememBeer.Business.Common.Contracts
{
    public interface IViewWithWarning
    {
        string WarningMessageText { get; set; }

        bool WarningErrorMessageVisible { get; set; }
    }
}
