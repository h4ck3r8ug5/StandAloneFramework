using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using InterviewQuestionGenerator.Extensions;
using InterviewQuestionGenerator.Handlers;
using System.Text;

namespace InterviewQuestionGenerator
{
    public static class ApplicationManager
    {
        #region Fields

        private static readonly List<string> requiredFiles = new List<string>
        {
            "Junior.xml",
            "intermediate.xml",
            "Senior.xml",
        };

        internal static FileStream JuniorInterviewQuestionFileStream;
        internal static FileStream IntermediateInterviewQuestionFileStream;
        internal static FileStream SeniorInterviewQuestionFileStream;

        #endregion

        #region Methods

        internal static void CheckForRequiredFiles()
        {
            var xmlString = new StringBuilder();
            xmlString.AppendLine("<QuestionAnswerSet>");
            xmlString.AppendLine("<QuestionsAnswers>");
            xmlString.AppendLine("</QuestionsAnswers>");
            xmlString.AppendLine("</QuestionAnswerSet>");

            byte[] bytes;

            if (!File.Exists(requiredFiles[0].ToString()))
            {
                JuniorInterviewQuestionFileStream = new FileStream(requiredFiles[0], FileMode.Create, FileAccess.ReadWrite, FileShare.None);

                bytes = Encoding.ASCII.GetBytes(xmlString.ToString());
                JuniorInterviewQuestionFileStream.Write(bytes, 0, bytes.Length);
                JuniorInterviewQuestionFileStream.Flush();
            }
            else
            {
                JuniorInterviewQuestionFileStream = new FileStream(requiredFiles[0], FileMode.Create, FileAccess.ReadWrite, FileShare.None);                
            }

            if (!File.Exists(requiredFiles[1].ToString()))
            {
                IntermediateInterviewQuestionFileStream = new FileStream(requiredFiles[1], FileMode.Create, FileAccess.ReadWrite, FileShare.None);

                bytes = Encoding.ASCII.GetBytes(xmlString.ToString());
                IntermediateInterviewQuestionFileStream.Write(bytes, 0, bytes.Length);
                IntermediateInterviewQuestionFileStream.Flush();
            }
            else
            {
                IntermediateInterviewQuestionFileStream = new FileStream(requiredFiles[1], FileMode.Create, FileAccess.ReadWrite, FileShare.None);
            }

            if (!File.Exists(requiredFiles[2].ToString()))
            {
                SeniorInterviewQuestionFileStream = new FileStream(requiredFiles[2], FileMode.Create, FileAccess.ReadWrite, FileShare.None);

                bytes = Encoding.ASCII.GetBytes(xmlString.ToString());
                SeniorInterviewQuestionFileStream.Write(bytes, 0, bytes.Length);
                SeniorInterviewQuestionFileStream.Flush();
            }
            else
            {
                SeniorInterviewQuestionFileStream = new FileStream(requiredFiles[2], FileMode.Create, FileAccess.ReadWrite, FileShare.None);
            }

            CacheManager.AddObjectToCache<FileStream>(ref JuniorInterviewQuestionFileStream);
            CacheManager.AddObjectToCache<FileStream>(ref IntermediateInterviewQuestionFileStream);
            CacheManager.AddObjectToCache<FileStream>(ref SeniorInterviewQuestionFileStream);
        }

        #endregion
    }
}
