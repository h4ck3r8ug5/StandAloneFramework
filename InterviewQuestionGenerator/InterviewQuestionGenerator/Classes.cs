namespace InterviewQuestionGenerator
{
    internal sealed class SystemMessage
    {
        internal enum SystemMessageType
        {
            Error,
            Success
        }

        internal string MessageText { get; set; }
        internal SystemMessageType MessageType { get; set; }
    }

    public sealed class DataWrapper
    {
        internal QuestionAnswerSet ExistingQuestions { get; set; }

        internal string InterviewXmlFile { get; set; }

        internal string DeveloperLevel { get; set; }
    }
}
