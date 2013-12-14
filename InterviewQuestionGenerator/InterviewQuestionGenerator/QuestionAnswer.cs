using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace InterviewQuestionGenerator
{
    public partial class QuestionAnswer : Form
    {
        public QuestionAnswer()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex > 0)
            {
                SaveQuestionAnswer(comboBox1.SelectedItem.ToString());
            }
        }

        private void SaveQuestionAnswer(string developerLevel)
        {
            var existingQuestions = developerLevel.DeserializeObject<QuestionAnswerSet>();
            if (existingQuestions != null)
            {
                var newQuestion = new LocalQuestionAnswer
                {
                    Question = txAddNewQuestion.Text,
                    Answer = txAddNewAnswer.Text,
                    Id = existingQuestions.QuestionsAnswers.Count + 1
                };

                if (!existingQuestions.QuestionsAnswers.Exists(x => x.Question == newQuestion.Question))
                {
                    existingQuestions.QuestionsAnswers.Add(newQuestion);
                }

                var saveResult = Helper.SaveQuestionSet(existingQuestions, developerLevel);

                if (saveResult.Item2)
                {
                    lblStatsMessage.Text = "Question Set was saved successfully";
                    lblStatsMessage.ForeColor = Color.ForestGreen;

                    txAddNewAnswer.Clear();
                    txAddNewQuestion.Clear();
                }
                else
                {
                    lblStatsMessage.Text = "Error: " + saveResult.Item1;
                    lblStatsMessage.ForeColor = Color.Red;

                    txAddNewQuestion.Focus();
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!File.Exists(comboBox1.SelectedItem + ".xml"))
            {
                File.Create(comboBox1.SelectedItem + ".xml");
            }
        }
    }
}
