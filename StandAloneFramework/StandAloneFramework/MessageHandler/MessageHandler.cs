using System;
using StandAloneFramework.FrameworkClasses;
using StandAloneFramework.Interfaces;

namespace StandAloneFramework
{
    public class MessageHandler : IMessageHandler
    {
        public void ShowMessage(InvocationResult invocationResult)
        {
            Console.WriteLine(invocationResult.Message);
        }
    }
}
