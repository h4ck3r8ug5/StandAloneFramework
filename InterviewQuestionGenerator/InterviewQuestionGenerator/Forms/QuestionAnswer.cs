using System;
using InterviewGeneratorFramework.Handlers;

namespace InterviewQuestionGenerator.Forms
{
    public partial class QuestionAnswer : ActionHandler
    {
        public QuestionAnswer()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex > 0)
            {

                DataWrapper.QuestionText = txAddNewQuestion.Text;
                DataWrapper.AnswerText = txAddNewAnswer.Text;
                DataWrapper.DeveloperLevel = comboBox1.SelectedItem + ".xml";

                ActionHandlerInstance.SaveQuestionSetData(DataWrapper);
            }
        }

        private void QuestionAnswer_Load(object sender, EventArgs e)
        {
            InitializeBaseMembers(GetHashCode());
        }
    }
}
