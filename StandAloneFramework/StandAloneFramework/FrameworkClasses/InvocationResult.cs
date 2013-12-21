﻿namespace StandAloneFramework.FrameworkClasses
{
    public class InvocationResult : MemoryManager<InvocationResult>
    {
        public enum InvocationResultType
        {
            Error,
            Success
        }
        public string Message { get; set; }
        public InvocationResultType MessageType { get; set; }
        public object Data { get; set; }
    }
}
