namespace BusinessRules.Base
{
    public enum RuleValidationMessageType
    {
        Information,
        Warning,
        Error,
        FatalErrror
    }

    public class RuleValidationMessage
    {
        public string ValidationMessage { get; set; }

        public RuleValidationMessageType RuleValidationMessageType { get; set; }
    }
}
