using System.Windows.Forms;
using InterviewGeneratorFramework.Classes;
using InterviewGeneratorFramework.Properties;

namespace InterviewGeneratorFramework.Handlers
{
    class MessageHandler
    {
        public static void ShowMessage(SystemMessage systemMessage, string messageText = "")
        {
            switch (systemMessage.MessageReason)
            {
                case SystemMessage.MessageType.InterviewFileDoesNotExist:
                    systemMessage.MessageText = !string.IsNullOrEmpty(messageText) ? messageText : string.Format(Resources.InterviewFileDoesNotExist, systemMessage.Arguments);
                    systemMessage.MessageTitle = Resources.ErrorTitle;
                    systemMessage.MessageBoxIcon = MessageBoxIcon.Error;
                    break;

                case SystemMessage.MessageType.XmlInterviewFileIsCorrupt:
                    systemMessage.MessageText = !string.IsNullOrEmpty(messageText) ? messageText : string.Format(Resources.XmlInterviewFileIsCorrupt, systemMessage.Arguments);
                    systemMessage.MessageTitle = Resources.ErrorTitle;
                    systemMessage.MessageBoxIcon = MessageBoxIcon.Error;
                    break;

                case SystemMessage.MessageType.QuestionSetUpdated:
                    systemMessage.MessageText = !string.IsNullOrEmpty(messageText) ? messageText : Resources.QuestionSetSuccessMessage;
                    systemMessage.MessageTitle = Resources.SuccessTitle;
                    systemMessage.MessageBoxIcon = MessageBoxIcon.Information;
                    break;
            }

            MessageBox.Show(systemMessage.MessageText, systemMessage.MessageTitle, MessageBoxButtons.OK, systemMessage.MessageBoxIcon);
        }               
    }
}
