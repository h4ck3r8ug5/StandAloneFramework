using System.Windows.Forms;

namespace InterviewGeneratorFramework.Classes
{
    internal sealed class SystemMessage
    {
        internal SystemMessage(MessageType messageType)
        {
            MessageReason = messageType;
        }

        internal SystemMessage()
        {
        }

        internal enum MessageType
        {
            InterviewFileDoesNotExist,
            XmlInterviewFileIsCorrupt,
            RequiredFilesDoNotExist,
            QuestionSetUpdated,
        }

        internal string MessageText { get; set; }
        internal MessageType MessageReason { get; set; }
        public string Arguments { get; set; }
        public string MessageTitle { get; set; }
        public MessageBoxIcon MessageBoxIcon { get; set; }
    }   
}
