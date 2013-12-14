namespace InterviewQuestionGenerator.Forms
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.questionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewSetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editSetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printSetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generateNewSetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.questionsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(494, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // questionsToolStripMenuItem
            // 
            this.questionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNewSetToolStripMenuItem,
            this.editSetToolStripMenuItem,
            this.printSetToolStripMenuItem,
            this.generateNewSetToolStripMenuItem});
            this.questionsToolStripMenuItem.Name = "questionsToolStripMenuItem";
            this.questionsToolStripMenuItem.Size = new System.Drawing.Size(72, 20);
            this.questionsToolStripMenuItem.Text = "&Questions";
            // 
            // addNewSetToolStripMenuItem
            // 
            this.addNewSetToolStripMenuItem.Name = "addNewSetToolStripMenuItem";
            this.addNewSetToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.addNewSetToolStripMenuItem.Text = "Add New Set";
            this.addNewSetToolStripMenuItem.Click += new System.EventHandler(this.addNewSetToolStripMenuItem_Click);
            // 
            // editSetToolStripMenuItem
            // 
            this.editSetToolStripMenuItem.Name = "editSetToolStripMenuItem";
            this.editSetToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.editSetToolStripMenuItem.Text = "Edit Set";
            this.editSetToolStripMenuItem.Click += new System.EventHandler(this.editSetToolStripMenuItem_Click);
            // 
            // printSetToolStripMenuItem
            // 
            this.printSetToolStripMenuItem.Name = "printSetToolStripMenuItem";
            this.printSetToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.printSetToolStripMenuItem.Text = "Print Set";
            // 
            // generateNewSetToolStripMenuItem
            // 
            this.generateNewSetToolStripMenuItem.Name = "generateNewSetToolStripMenuItem";
            this.generateNewSetToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.generateNewSetToolStripMenuItem.Text = "Generate New Set";
            this.generateNewSetToolStripMenuItem.Click += new System.EventHandler(this.generateNewSetToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 347);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Interview Question Generator";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem questionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addNewSetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editSetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printSetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generateNewSetToolStripMenuItem;
    }
}

