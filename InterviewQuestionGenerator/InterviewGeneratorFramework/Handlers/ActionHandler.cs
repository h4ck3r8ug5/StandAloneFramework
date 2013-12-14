using System.Windows.Forms;
using InterviewGeneratorFramework.Classes;
using InterviewGeneratorFramework.PDFGenerator;

namespace InterviewGeneratorFramework.Handlers
{
    public class ActionHandler : Form
    {
        #region Properties

        protected static ActionHandler ActionHandlerInstance { get; set; }

        private static DataHandler DataManager { get; set; }

        protected DataWrapper DataWrapper { get; set; }

        protected PdfGenerator PdfGenerator { get; set; }

        #endregion

        #region Constructor

        public ActionHandler()
        {           
            PdfGenerator = new PdfGenerator();
        }

        #endregion

        #region Methods

        protected internal void InitializeBaseMembers(int hashCode)
        {
            ActionHandlerInstance = CacheManager.CacheManager.GetObjectFromCache<ActionHandler>(hashCode);
            DataManager = CacheManager.CacheManager.GetObjectFromCache<DataHandler>(hashCode);
            DataWrapper = CacheManager.CacheManager.GetObjectFromCache<DataWrapper>(hashCode);
        }

        public void GenerateInterviewQuestions(DataWrapper dataWrapper)
        {
            PdfGenerator.CreateInterviewPdf(dataWrapper);
        }

        public QuestionAnswerSet LoadQuestionSet(DataWrapper dataWrapper)
        {
            return DataManager.LoadQuestions(dataWrapper);
        }

        public void SaveQuestionSetData(DataWrapper dataWrapper)
        {
            DataManager.SaveQuestionSetData(dataWrapper);
        }
     
        #endregion
    }
}
