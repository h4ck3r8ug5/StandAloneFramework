using System.Windows.Forms;
using InterviewQuestionGenerator.Properties;

namespace InterviewQuestionGenerator.Handlers
{
    class MessageHandler
    {
        private static string messageText;

        public static void ShowFailMessage(SystemMessage systemMessage)
        {
            switch (systemMessage.FailureMessageReason)
            {
                case SystemMessage.FailureMessageType.InterviewFileDoesNotExist:                    
                    messageText = string.Format(Resources.InterviewFileDoesNotExist,systemMessage.Arguments);
                    break;

                case SystemMessage.FailureMessageType.XmlInterviewFileIsCorrupt:
                    messageText = string.Format(Resources.XmlInterviewFileIsCorrupt, systemMessage.Arguments);
                    break;                
            }

            MessageBox.Show(messageText, Resources.ErrorMessageTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }       
    }
}
