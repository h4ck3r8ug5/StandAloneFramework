using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace InterviewGeneratorFramework.Classes
{
    [Serializable]
    public class QuestionAnswerSet
    {        
        [XmlArray]
        public List<LocalQuestionAnswer> QuestionsAnswers { get; set; }
    }
}
