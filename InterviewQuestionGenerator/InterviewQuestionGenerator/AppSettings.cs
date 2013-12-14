using System.Configuration;
using InterviewQuestionGenerator.Extensions;

namespace InterviewQuestionGenerator
{
    public static class AppSettings
    {
        #region Properties

        private static string JuniorInterviewFile
        {
            get
            {
                return ConfigurationManager.AppSettings.GetInterviewFile("juniorInterviewFile");
            }
            
        }

        private static string IntermediateInterviewFile
        {
            get
            {
                return ConfigurationManager.AppSettings.GetInterviewFile("intermediateInterviewFile");
            }
        }

        private static string SeniorInterviewFile
        {
            get
            {
                return ConfigurationManager.AppSettings.GetInterviewFile("seniorInterviewFile");
            }
        }

        #endregion 

        #region Methods

        internal static string GetInterviewFile(string developerLevel)
        {
            switch (developerLevel)
            {
                case "Junior":
                    return JuniorInterviewFile;

                case "Intermediate":
                    return IntermediateInterviewFile;

                case "Senior":
                    return SeniorInterviewFile;
            }

            return string.Empty;
        }

        #endregion
    }
}
