﻿using System;
using System.Linq;
using System.Windows.Forms;
using InterviewGeneratorFramework.Handlers;

namespace InterviewQuestionGenerator.Forms
{
    internal sealed partial class GenerateNewQuestionsSet : ActionHandler
    {
        private readonly Form1 frmMain;
       
        public GenerateNewQuestionsSet(Form1 form1)
        {
            frmMain = form1;
            InitializeComponent();
            InitializeBaseMembers(GetHashCode());

            foreach (var control in groupBox1.Controls.OfType<ComboBox>())
            {
                control.SelectedIndexChanged +=
                delegate
                {
                    if (control.SelectedIndex > 0)
                    {
                        DataWrapper.DeveloperLevel = control.SelectedItem + ".xml";
                    }
                };
            }
        }
      
        private void button1_Click(object sender, EventArgs e)
        {
            ActionHandlerInstance.GenerateInterviewQuestions(DataWrapper);
            
            Close();
        }

        private void GenerateNewQuestionsSet_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmMain.Show();
        }     
    }
}
