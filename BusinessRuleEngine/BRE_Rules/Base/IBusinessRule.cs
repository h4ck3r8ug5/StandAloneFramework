using System.Text.RegularExpressions;

namespace BusinessRules.Base
{
    public interface IBusinessRule
    {
        object RuleTarget { get; set; }
        string RuleValidationMessageText { get; set; }
        bool IsValid { get; set; }
        Regex RegularExpressionHandler { get; set; }
        void ValidateRule();
        object Owner { get; set; }
    }
}
