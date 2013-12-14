using System;
using System.Windows.Forms;
using InterviewGeneratorFramework.CacheManager;
using InterviewQuestionGenerator.Forms;

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
            Application.Run(new Form1());         
        }        
    }
}
