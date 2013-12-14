using System;
using System.Windows.Forms;
using InterviewQuestionGenerator.Forms;
using System.Threading;

namespace InterviewQuestionGenerator
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            new CacheManager();

            Thread thAppManager = new Thread(CheckApp);
            thAppManager.IsBackground = true;
            thAppManager.Start();
           
            Application.Run(new Form1());         
        }

        static void CheckApp()
        {
            ApplicationManager.CheckForRequiredFiles();
        }
    }
}
