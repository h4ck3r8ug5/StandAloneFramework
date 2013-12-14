using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace InterviewQuestionGenerator
{
    public partial class EditQuestionSet : Form
    {
        public EditQuestionSet()
        {
            InitializeComponent();
        }

        private QuestionAnswerSet QuestionAnswers { get; set; }

        internal void SaveNewData()
        {
            var questionAnswerSet = new QuestionAnswerSet
            {
                QuestionsAnswers = (List<LocalQuestionAnswer>)(dataGridView1.DataSource as BindingSource).DataSource,
            };

            var result = Helper.SaveQuestionSet(questionAnswerSet, comboBox1.SelectedItem.ToString());
            if (result.Item2)
            {
                lblStatsMessage.Text = "Question Set was saved successfully";
                lblStatsMessage.ForeColor = Color.ForestGreen;
            }
            else
            {
                lblStatsMessage.Text = "Error: " + result.Item1;
                lblStatsMessage.ForeColor = Color.Red;
            }

            lblStatsMessage.Visible = true;
        }

        internal int clickCount = 0;
        private int selectedRowIndex;

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            QuestionAnswers = Helper.GetQuestionAnswerSet(comboBox1.SelectedItem.ToString());

            if (QuestionAnswers == null)
            {
                lblStatsMessage.Text = "Error: The "+ comboBox1.SelectedItem + " level Xml file does not exist. Pleas add it to the bin directory.";
                lblStatsMessage.ForeColor = Color.Red;
                lblStatsMessage.Visible = true;
            }
            else
            {
                var bindingSource = new BindingSource
           {
               DataSource = QuestionAnswers.QuestionsAnswers,
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
            var targetQuestionAnswer = QuestionAnswers.QuestionsAnswers.Find(x => x.Id == targetIndex);
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
                dataGridView1.SelectionMode = e.ColumnIndex == 0
                    ? DataGridViewSelectionMode.FullRowSelect
                    : DataGridViewSelectionMode.RowHeaderSelect;
                dataGridView1.Rows[e.RowIndex].Selected = true;
                dataGridView1.Columns[2].Visible = true;

                selectedRowIndex = e.RowIndex == 0 ? 0 : e.RowIndex - 1;
            }
            else
            {
                var text = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                var targetCell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                dataGridView1.SelectionMode = e.ColumnIndex == 0
                    ? DataGridViewSelectionMode.FullRowSelect
                    : DataGridViewSelectionMode.RowHeaderSelect;

                var contentEditor = new ContentEditor(this, ref targetCell, e, sender);
                contentEditor.textBox1.Text = text;
                contentEditor.Show();

                clickCount++;
            }
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void dataGridView1_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                SaveNewData();
            }
        }

        private void EditQuestionSet_Load(object sender, EventArgs e)
        {
            lblStatsMessage.Visible = false;
        }
    }
}