﻿using System.Windows.Forms;

namespace InterviewQuestionGenerator.Handlers
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

        internal void InitializeBaseMembers(int hashCode)
        {
            ActionHandlerInstance = CacheManager.GetObjectFromCache<ActionHandler>(hashCode);
            DataManager = CacheManager.GetObjectFromCache<DataHandler>(hashCode);
            DataWrapper = CacheManager.GetObjectFromCache<DataWrapper>(hashCode);
        }
      
        internal void GenerateInterviewQuestions(DataWrapper dataWrapper)
        {
            PdfGenerator.CreateInterviewPdf(dataWrapper);
        }
             
        internal QuestionAnswerSet LoadQuestionSet(DataWrapper dataWrapper)
        {
            return DataManager.LoadQuestions(dataWrapper);
        }

        internal void SaveQuestionSetData(DataWrapper dataWrapper)
        {
            DataManager.SaveQuestionSetData(dataWrapper);
        }
     
        #endregion
    }
}
