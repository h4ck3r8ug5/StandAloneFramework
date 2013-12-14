using System;
using System.IO;
using System.Linq;
using InterviewQuestionGenerator.Extensions;

namespace InterviewQuestionGenerator.Handlers
{
    public class DataHandler : CacheManager
    {
        internal object taskExecuter;
        private Tuple<SystemMessage, object> executionResult;

        internal QuestionAnswerSet LoadQuestions(DataWrapper dataWrapper)
        {
            taskExecuter = new Func<DataWrapper, QuestionAnswerSet>(InternalDeserializeObject<QuestionAnswerSet>);
            executionResult = taskExecuter.ExecuteAndHandleAnyErrors<DataWrapper, QuestionAnswerSet>(dataWrapper);

            if (executionResult.IsObjectNull() || executionResult.Item2.IsObjectNull())
            {
                return default(QuestionAnswerSet);
            }

            return executionResult.Item2 as QuestionAnswerSet;
        }

        internal void SaveQuestionSetData(DataWrapper dataWrapper)
        {
            var action = new Action<DataWrapper>(InternalSaveQuestionSetData);
            action.ExecuteAndHandleAnyErrors<DataWrapper>(dataWrapper);
        }

        #region Private Methods

        private void InternalSave(DataWrapper data)
        {
            var xmlString = data.ExistingQuestions.SerializeObject<QuestionAnswerSet>();

            File.WriteAllText(data.InterviewXmlFile, xmlString);
        }

        private T InternalDeserializeObject<T>(DataWrapper dataWrapper) where T : class
        {
            return dataWrapper.DeveloperLevel.DeserializeObject<T>(dataWrapper.TargetFileStream);
        }

        private void InternalSaveQuestionSetData(DataWrapper dataWrapper)
        {
            var existingQuestionAnswerSet = LoadQuestions(dataWrapper);

            if (existingQuestionAnswerSet.IsObjectNotNull())
            {
                var existingQuestionAnswer = existingQuestionAnswerSet.QuestionsAnswers.FirstOrDefault(x => x.Question == dataWrapper.QuestionText && x.Id == dataWrapper.Id);

                if (existingQuestionAnswer.IsObjectNull())
                {
                    var newQuestion = new LocalQuestionAnswer
                    {
                        Id = existingQuestionAnswerSet.QuestionsAnswers.Count + 1,
                        Question = dataWrapper.QuestionText,
                        Answer = dataWrapper.AnswerText,
                    };

                    existingQuestionAnswerSet.QuestionsAnswers.Add(newQuestion);
                }
                else
                {
                    existingQuestionAnswer.Answer = dataWrapper.AnswerText;
                    existingQuestionAnswer.Question = dataWrapper.QuestionText;
                    existingQuestionAnswer.Id = dataWrapper.Id;
                    existingQuestionAnswerSet.QuestionsAnswers.RemoveAt(dataWrapper.Id);
                    existingQuestionAnswerSet.QuestionsAnswers.Insert(dataWrapper.Id, existingQuestionAnswer);
                }

                dataWrapper.ExistingQuestions = existingQuestionAnswerSet;
                dataWrapper.InterviewXmlFile = dataWrapper.DeveloperLevel;

                taskExecuter = new Action<DataWrapper>(InternalSave);
                taskExecuter.ExecuteAndHandleAnyErrors<DataWrapper>(dataWrapper);
            }
        }

        #endregion
    }
}
