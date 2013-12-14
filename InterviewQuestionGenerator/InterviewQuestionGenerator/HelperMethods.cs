using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Image = iTextSharp.text.Image;
using Rectangle = iTextSharp.text.Rectangle;

namespace InterviewQuestionGenerator
{
    public static class HelperMethods
    {
        public static SortedList FilesLookup
        {
            get
            {
                return new SortedList
                {
                    {"Junior", "junior.xml"},
                    {"Intermediate", "intermediate.xml"},
                    {"Senior", "senior.xml"}
                };
            }
        }

        internal static string SerializeObject<T>(this object targetObject)
        {
            using (var ms = new MemoryStream())
            {
                var xmlSerializer = new XmlSerializer(typeof(T));

                var settings = new XmlWriterSettings
                {
                    Indent = true,
                    OmitXmlDeclaration = true,
                    Encoding = Encoding.ASCII
                };

                var writer = XmlWriter.Create(ms, settings);
                var xmlNamespace = new XmlSerializerNamespaces();
                xmlNamespace.Add("", "");
                xmlSerializer.Serialize(writer, targetObject, xmlNamespace);
                return Encoding.ASCII.GetString(ms.ToArray());
            }
        }

        internal static T DeserializeObject<T>(this object targetObject) where T : class
        {
            var file = FilesLookup.GetByIndex(FilesLookup.IndexOfKey((targetObject))).ToString();

            var xmlSerializer = new XmlSerializer(typeof(QuestionAnswerSet));

            if (File.Exists(file))
            {
                using (var fileStream = new FileStream(file, FileMode.Open, FileAccess.Read, FileShare.None))
                {
                    var existingQuestions = (QuestionAnswerSet)xmlSerializer.Deserialize(fileStream);
                    return existingQuestions != null ? (existingQuestions as T) : default(T);
                }
            }
            return default(T);
        }
    }

    public class Helper
    {
        static StreamReader fileToPrint;
        static System.Drawing.Font printFont;
        private static readonly Hashtable selectedQuestions = new Hashtable();
        internal static void GenerateInterviewQuestions(string developerLevel)
        {
            var pdf = new Document();
            selectedQuestions.Clear();

            var writer = PdfWriter.GetInstance(pdf, new FileStream("interview questions.pdf", FileMode.Create));

            pdf.SetMargins(30, 30, 30, 30);
            pdf.SetPageSize(new Rectangle(PageSize.LETTER.Width, PageSize.LETTER.Height));

            pdf.Open();

            var questions = LoadQuestions(developerLevel);

            for (; ; )
            {
                var questionAnswerIndex = GenerateRandomNumber(questions.QuestionsAnswers.Count);

                if (selectedQuestions.ContainsKey(questionAnswerIndex) && selectedQuestions.Count != questions.QuestionsAnswers.Count)
                {
                    continue;
                }
              
                var chosenQuestionAnswer = questions.QuestionsAnswers.Find(x => x.Id == questionAnswerIndex);
                if (!selectedQuestions.ContainsKey(chosenQuestionAnswer.Id) && selectedQuestions.Count <= 10)
                {
                    selectedQuestions.Add(chosenQuestionAnswer.Id, chosenQuestionAnswer);
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
                    Phrase = new Phrase("Version: 1.0"),
                    HorizontalAlignment = Element.ALIGN_CENTER,
                    VerticalAlignment = Element.ALIGN_MIDDLE,
                    FixedHeight = 30.00F,
                },
                new PdfPCell
                {
                    Phrase = new Phrase(developerLevel + " Developer Interview Questions"),
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

            selectedQuestions.Values.Cast<LocalQuestionAnswer>().OrderBy(x => x.Id).ToList().ForEach(questionAnswer =>
            {
                var question = string.Format("{0}: {1}", questionAnswer.Id, questionAnswer.Question);
                pdf.Add(new Paragraph(question));

                pdf.Add(new Paragraph(Chunk.NEWLINE));
            });
           
            pdf.Add(new Paragraph("==========================================================================="));
            pdf.Add(new Paragraph("Answers"));
            pdf.Add(new Paragraph("==========================================================================="));

            pdf.Add(new Paragraph(Chunk.NEWLINE));

            selectedQuestions.Values.Cast<LocalQuestionAnswer>().OrderBy(x => x.Id).ToList().ForEach(questionAnswer =>
            {
                var answer = string.Format("{0}: {1}", questionAnswer.Id, questionAnswer.Answer);
                pdf.Add(new Paragraph(answer));

                pdf.Add(new Paragraph(Chunk.NEWLINE));
            });

            writer.Flush();
            pdf.Close();
            Process.Start("interview questions.pdf");
        }

        internal static Tuple<string, bool> SaveQuestionSet(QuestionAnswerSet existingQuestions, string developerLevel)
        {
            try
            {
                var file = HelperMethods.FilesLookup.GetByIndex(HelperMethods.FilesLookup.IndexOfKey((developerLevel))).ToString();

                var xmlString = existingQuestions.SerializeObject<QuestionAnswerSet>();

                File.WriteAllText(file, xmlString);

                return new Tuple<string, bool>("", true);      
            }
            catch (Exception ex)
            {
                return new Tuple<string, bool>(ex.Message, false);
            }
        }

        internal static QuestionAnswerSet LoadQuestions(string developerLevel)
        {
            var file = HelperMethods.FilesLookup.GetKey(HelperMethods.FilesLookup.IndexOfKey((developerLevel))).ToString();

            return file.DeserializeObject<QuestionAnswerSet>();
        }

        private static int GenerateRandomNumber(int seed)
        {
            return new Random().Next(1, seed);
        }
        internal static QuestionAnswerSet GetQuestionAnswerSet(string developerLevel)
        {
            return LoadQuestions(developerLevel);
        }
    }
}
