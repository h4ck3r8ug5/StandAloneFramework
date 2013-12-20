namespace BusinessRules.Base
{
    public class BaseTypes
    {
        public class Message
        {
            public string Code { get; set; }
            public string MessageType { get; set; }
        }
    }

    public struct MessageType
    {
        public enum MessageTypes
        {
            Information,
            Warning,
            Error
        }
    }
}
