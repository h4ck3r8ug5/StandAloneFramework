namespace StandAloneFramework.FrameworkClasses
{
    public class InvocationResult
    {
        public enum InvocationResultType
        {
            Error,
            Success
        }
        public string Message { get; set; }
        public InvocationResultType MessageType { get; set; }
    }
}
