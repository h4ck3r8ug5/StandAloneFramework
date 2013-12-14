using System;
using System.Collections.Generic;
using System.Windows.Forms;
using InterviewGeneratorFramework.Classes;
using InterviewGeneratorFramework.Handlers;
using InterviewGeneratorFramework.Extensions;

namespace InterviewQuestionGenerator.Forms
{
    public partial class EditQuestionSet : ActionHandler
    {
        public EditQuestionSet()
        {
            InitializeComponent();
            InitializeBaseMembers(GetHashCode());
        }

        private QuestionAnswerSet questionAnswerSet;
        internal int clickCount = 0;
        private int selectedRowIndex;

        internal void SaveNewData()
        {
            var bindingSource = dataGridView1.DataSource as BindingSource;
            if (bindingSource != null)
            {
                questionAnswerSet = new QuestionAnswerSet
                {
                    QuestionsAnswers = (List<LocalQuestionAnswer>) bindingSource.DataSource,
                };
            }

            DataWrapper = new DataWrapper
            {
                DeveloperLevel = comboBox1.SelectedItem + ".xml",
                InterviewXmlFile = comboBox1.SelectedItem + ".xml",
                ExistingQuestions = questionAnswerSet,
            };

           ActionHandlerInstance.SaveQuestionSetData(DataWrapper);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataWrapper.DeveloperLevel = comboBox1.SelectedItem + ".xml";

            questionAnswerSet = ActionHandlerInstance.LoadQuestionSet(DataWrapper);

            if (questionAnswerSet.IsObjectNotNull())
            {
                var bindingSource = new BindingSource
                {
                    DataSource = questionAnswerSet.QuestionsAnswers,
                };

                dataGridView1.DataSource = bindingSource;
                dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dataGridView1.Columns[1].Width = 300;
                dataGridView1.Columns[2].Width = 300;

                dataGridView1.Columns[0].DataPropertyName = "Id";
                dataGridView1.Columns[1].DataPropertyName = "Question";
                dataGridView1.Columns[2].DataPropertyName = "Answer";
            }          
        }

        internal void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var targetIndex = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            var changedText = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            var targetQuestionAnswer = questionAnswerSet.QuestionsAnswers.Find(x => x.Id == targetIndex);
            var affectedColumn = e.ColumnIndex == 1 ? "Question" : "Answer";

            if (affectedColumn == "Question")
            {
                targetQuestionAnswer.Question = changedText;
            }
            else
            {
                targetQuestionAnswer.Answer = changedText;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            lblStatsMessage.Visible = false;
            if (clickCount == 1)
            {
                return;
            }

            if (e.ColumnIndex == 0)
            {
                dataGridView1.SelectionMode = e.ColumnIndex == 0 ? DataGridViewSelectionMode.FullRowSelect
                                                                 : DataGridViewSelectionMode.RowHeaderSelect;

                dataGridView1.Rows[e.RowIndex].Selected = true;
                dataGridView1.Columns[2].Visible = true;

                selectedRowIndex = e.RowIndex == 0 ? 0 : e.RowIndex - 1;
            }
            else
            {
                var text = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                var targetCell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                dataGridView1.SelectionMode = e.ColumnIndex == 0 ? DataGridViewSelectionMode.FullRowSelect
                                                                 : DataGridViewSelectionMode.RowHeaderSelect;

                var contentEditor = new ContentEditor(this, ref targetCell, e, sender)
                {
                    textBox1 = {Text = text}
                };

                contentEditor.Show();

                clickCount++;
            }
        }
      
        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            //This must be left to handle binding data errors silently
        }

        private void dataGridView1_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                SaveNewData();
            }
        }
    }
}