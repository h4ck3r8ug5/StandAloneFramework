using System;
using InterviewGeneratorFramework.Handlers;

namespace InterviewQuestionGenerator.Forms
{
    public partial class Form1 : ActionHandler
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
        }

        private void editSetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new EditQuestionSet().Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitializeBaseMembers(this.GetHashCode());
        }
    }
}
