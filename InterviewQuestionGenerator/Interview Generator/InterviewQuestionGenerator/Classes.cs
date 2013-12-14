using System.Collections.Generic;
using System.IO;

namespace InterviewQuestionGenerator
{
    internal sealed class SystemMessage
    {
        internal enum FailureMessageType
        {
            InterviewFileDoesNotExist,
            XmlInterviewFileIsCorrupt,
            RequiredFilesDoNotExist
        }

        internal string MessageText { get; set; }
        internal FailureMessageType FailureMessageReason { get; set; }
        public string Arguments { get; set; }
    }

    public sealed class DataWrapper
    {
        public int Id { get; set; }

        internal QuestionAnswerSet ExistingQuestions { get; set; }

        internal string InterviewXmlFile { get; set; }

        internal string DeveloperLevel { get; set; }

        internal string AnswerText { get; set; }

        internal string QuestionText { get; set; }

        internal IList<object> Arguments { get; set; }

        public FileStream TargetFileStream { get; set; }
    }
}
