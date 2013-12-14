using System;
using System.Windows.Forms;

namespace InterviewQuestionGenerator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void addNewSetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new QuestionAnswer().Show();
        }

        private void generateNewSetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var generateNewQuestionSet = new GenerateNewQuestionsSet(this);
            generateNewQuestionSet.Show();
            Hide();
        }

        private void editSetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new EditQuestionSet().Show();
        }
    }
}
