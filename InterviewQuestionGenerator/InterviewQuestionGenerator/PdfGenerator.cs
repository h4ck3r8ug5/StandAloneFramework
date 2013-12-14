using System;
using System.Collections.Generic;
using iTextSharp.text;
using System.IO;
using InterviewQuestionGenerator.Handlers;
using iTextSharp.text.pdf;
using System.Collections;
using System.Diagnostics;
using System.Reflection;
using System.Linq;

namespace InterviewQuestionGenerator
{
    public class PdfGenerator : DataHandler
    {
        #region Properties

        protected DataHandler DataManager { get; set; }

        /// <summary>
        /// Gets or sets the pseudo random generator.
        /// </summary>
        /// <value>The pseudo random generator.</value>
        private Random PseudoRandomGenerator { get; set; }

        /// <summary>
        /// Gets or sets the selected questions.
        /// </summary>
        /// <value>The selected questions.</value>
        private Hashtable SelectedQuestions { get; set; }

        #endregion

        #region Constructor

        public PdfGenerator()
        {
            SelectedQuestions = new Hashtable();
            PseudoRandomGenerator = new Random();
            DataManager = GetObjectFromCache<DataHandler>(new DataHandler().GetHashCode());
        }

        #endregion

        #region Methods

        internal void CreateInterviewPdf(DataWrapper dataWrapper)
        {
            DataManager.taskExecuter = new Action<DataWrapper>(CreatePdf);
            DataManager.taskExecuter.ExecuteAndHandleAnyErrors<DataWrapper>(dataWrapper);
        }

        #endregion

        #region Private Methods

        private void CreatePdf(DataWrapper dataWrapper)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var fileVersionInfo = FileVersionInfo.GetVersionInfo(assembly.Location);
            var version = fileVersionInfo.ProductVersion;

            var pdf = new Document();

            var writer = PdfWriter.GetInstance(pdf, new FileStream("interview questions.pdf", FileMode.Create, FileAccess.Write, FileShare.None));

            pdf.SetMargins(30, 30, 30, 30);
            pdf.SetPageSize(new Rectangle(PageSize.LETTER.Width, PageSize.LETTER.Height));

            pdf.Open();

            var questions = DataManager.LoadQuestions(dataWrapper);

            if (questions.IsObjectNull())
            {
                return;
            }

            for (; ;)
            {
                if (questions.QuestionsAnswers.Count == 1)
                {
                    SelectedQuestions.Add(questions.QuestionsAnswers.First().Id, questions.QuestionsAnswers.First());
                    break;
                }

                var questionAnswerIndex = GenerateRandomNumber(questions.QuestionsAnswers.Count);

                if (SelectedQuestions.ContainsKey(questionAnswerIndex) && SelectedQuestions.Count > 1)
                {
                    continue;
                }

                var chosenQuestionAnswer = questions.QuestionsAnswers.Find(x => x.Id == questionAnswerIndex);
                if (chosenQuestionAnswer != null)
                {
                    if (!SelectedQuestions.ContainsKey(chosenQuestionAnswer.Id) && SelectedQuestions.Count <= 10)
                    {
                        SelectedQuestions.Add(chosenQuestionAnswer.Id, chosenQuestionAnswer);
                    }
                }

                else
                {
                    break;
                }
            }

            var logoTable = new PdfPTable(new[] { 20.00f, 60.00f, 40.00f })
            {
                WidthPercentage = 100.00f
            };

            var logo = Image.GetInstance("logo.png");
            logo.ScalePercent(20.0f);

            var pdfpCells = new List<PdfPCell>
            {
                 new PdfPCell
                {
                    Image = logo,
                    HorizontalAlignment = Element.ALIGN_LEFT,
                    Border = 0
                },
                new PdfPCell {Border = 0},
                new PdfPCell {Border = 0}
            };

            var pdpfRow = new PdfPRow(pdfpCells.ToArray());

            pdfpCells = new List<PdfPCell>
            {
                new PdfPCell
                {
                    Phrase = new Phrase("Version: " + version),
                    HorizontalAlignment = Element.ALIGN_CENTER,
                    VerticalAlignment = Element.ALIGN_MIDDLE,
                    FixedHeight = 30.00F,
                },
                new PdfPCell
                {
                    Phrase = new Phrase(dataWrapper.DeveloperLevel + " Developer Interview Questions"),
                    HorizontalAlignment = Element.ALIGN_CENTER,
                    VerticalAlignment = Element.ALIGN_MIDDLE,
                    FixedHeight = 30.00F
                },
                new PdfPCell
                {
                    Phrase = new Phrase("Generated Date: " + DateTime.Now.ToShortDateString()),
                    HorizontalAlignment = Element.ALIGN_CENTER,                    
                    VerticalAlignment = Element.ALIGN_MIDDLE,
                    FixedHeight = 30.00F
                }
            };

            logoTable.Rows.Add(pdpfRow);

            pdpfRow = new PdfPRow(pdfpCells.ToArray());

            logoTable.Rows.Add(pdpfRow);

            pdf.Add(logoTable);

            pdf.Add(new Paragraph(Chunk.NEWLINE));

            pdf.Add(new Paragraph("==========================================================================="));
            pdf.Add(new Paragraph("Questions"));
            pdf.Add(new Paragraph("==========================================================================="));

            SelectedQuestions.Values.Cast<LocalQuestionAnswer>().OrderBy(x => x.Id).ToList().ForEach(questionAnswer =>
            {
                var question = String.Format("{0}: {1}", questionAnswer.Id, questionAnswer.Question);
                pdf.Add(new Paragraph(question));

                pdf.Add(new Paragraph(Chunk.NEWLINE));
            });

            pdf.Add(new Paragraph("==========================================================================="));
            pdf.Add(new Paragraph("Answers"));
            pdf.Add(new Paragraph("==========================================================================="));

            pdf.Add(new Paragraph(Chunk.NEWLINE));

            SelectedQuestions.Values.Cast<LocalQuestionAnswer>().OrderBy(x => x.Id).ToList().ForEach(questionAnswer =>
            {
                var answer = String.Format("{0}: {1}", questionAnswer.Id, questionAnswer.Answer);
                pdf.Add(new Paragraph(answer));

                pdf.Add(new Paragraph(Chunk.NEWLINE));
            });

            writer.Flush();
            pdf.Close();
            Process.Start("interview questions.pdf");
        }

        /// <summary>
        /// Generates the random number.
        /// </summary>
        /// <param name="seed">The seed</param>
        /// <returns>A random number</returns>
        private int GenerateRandomNumber(int seed)
        {
            return PseudoRandomGenerator.Next(1, seed);
        }

        #endregion
    }
}
