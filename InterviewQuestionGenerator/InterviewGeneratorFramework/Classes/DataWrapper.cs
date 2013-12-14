using System.Collections.Generic;

namespace InterviewGeneratorFramework.Classes
{
    public sealed class DataWrapper
    {
        public int Id { get; set; }

        public QuestionAnswerSet ExistingQuestions { get; set; }

        public string InterviewXmlFile { get; set; }

        public string DeveloperLevel { get; set; }

        public string AnswerText { get; set; }

        public string QuestionText { get; set; }

        internal IList<object> Arguments { get; set; }

    }
}
