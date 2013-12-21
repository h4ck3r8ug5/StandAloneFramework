using System.Text.RegularExpressions;

namespace Cross.Cutting.Concerns.Common.Interfaces
{
    public interface IBusinessRule
    {
        object RuleTarget { get; set; }
        string NotificationMessage { get; set; }
        bool IsValid { get; set; }
        Regex RegularExpressionHandler { get; set; }
        void ValidateRule();
        object Owner { get; set; }
    }
}
