using System;
using System.Windows.Forms;

namespace InterviewQuestionGenerator
{
    public partial class GenerateNewQuestionsSet : Form
    {
        private readonly Form1 frmMain;
        public GenerateNewQuestionsSet(Form1 form1)
        {
            frmMain = form1;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Helper.GenerateInterviewQuestions(comboBox1.SelectedItem.ToString());

            Close();
        }

        private void GenerateNewQuestionsSet_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmMain.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var result = Helper.LoadQuestions(comboBox1.SelectedItem.ToString());
            button1.Enabled = (result.QuestionsAnswers.Count == 0) ? false : true;
        }      
    }
}
