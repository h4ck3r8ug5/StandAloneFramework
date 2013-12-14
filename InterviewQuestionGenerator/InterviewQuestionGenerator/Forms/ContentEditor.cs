using System;
using System.Windows.Forms;
using InterviewGeneratorFramework.Handlers;

namespace InterviewQuestionGenerator.Forms
{
    public partial class ContentEditor : ActionHandler
    {
        private readonly EditQuestionSet editQuestionSet;
        private readonly DataGridViewCell targetCell;
        private readonly string originalText;
        private readonly DataGridViewCellEventArgs dataGridViewCellEventArgs;
        private readonly object sender;

        public ContentEditor(EditQuestionSet editQuestionSet, ref DataGridViewCell targetCell, DataGridViewCellEventArgs dataGridViewCellEventArgs, object sender)                            
        {
            InitializeComponent();

            this.editQuestionSet = editQuestionSet;
            this.targetCell = targetCell;
            originalText = textBox1.Text;
            this.dataGridViewCellEventArgs = dataGridViewCellEventArgs;
            this.sender = sender;
        }

        private void ContentEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (originalText != textBox1.Text)
            {
                editQuestionSet.clickCount = 0;
            }
            else
            {
                e.Cancel = true;
            }           
        }
      
        private void button1_Click(object sender, EventArgs e)
        {
            editQuestionSet.dataGridView1.EndEdit();
            editQuestionSet.dataGridView1_CellEndEdit(this.sender,dataGridViewCellEventArgs);
            targetCell.Value = textBox1.Text;
            editQuestionSet.SaveNewData();
            
            Close();
        }
    }
}
