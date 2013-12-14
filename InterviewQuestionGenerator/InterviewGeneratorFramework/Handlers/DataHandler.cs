using System;
using System.IO;
using System.Linq;
using InterviewGeneratorFramework.Classes;
using InterviewGeneratorFramework.Extensions;

namespace InterviewGeneratorFramework.Handlers
{
    public class DataHandler : CacheManager.CacheManager
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
            var action = new Func<DataWrapper, Tuple<SystemMessage, object>>(InternalSaveQuestionSetData);

            var result = action.ExecuteAndHandleAnyErrors<DataWrapper, Tuple<SystemMessage, object>>(dataWrapper);
            if (result.Item1.IsObjectNull())
            {
                MessageHandler.ShowMessage(new SystemMessage(SystemMessage.MessageType.QuestionSetUpdated));
            }            
        }

        #region Private Methods

        private void InternalSave(DataWrapper data)
        {
            var xmlString = data.ExistingQuestions.SerializeObject<QuestionAnswerSet>();

            File.WriteAllText(data.InterviewXmlFile, xmlString);
        }

        private T InternalDeserializeObject<T>(DataWrapper dataWrapper) where T : class
        {
            return dataWrapper.DeveloperLevel.DeserializeObject<T>();
        }

        private Tuple<SystemMessage, object> InternalSaveQuestionSetData(DataWrapper dataWrapper)
        {
            var existingQuestionAnswerSet = LoadQuestions(dataWrapper);

            if (existingQuestionAnswerSet.IsObjectNotNull())
            {
                LocalQuestionAnswer existingQuestionAnswer = null;

                existingQuestionAnswerSet.QuestionsAnswers.ForEach(questionAnswer => dataWrapper.ExistingQuestions.QuestionsAnswers.ForEach(dataWrapperQuestionAnswer =>
                {
                    if (questionAnswer.Id == dataWrapperQuestionAnswer.Id)
                    {
                        existingQuestionAnswer = questionAnswer;
                    }        
               }));                

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
                    existingQuestionAnswer.Answer = dataWrapper.ExistingQuestions.QuestionsAnswers.First().Answer;
                    existingQuestionAnswer.Question = dataWrapper.ExistingQuestions.QuestionsAnswers.First().Question;
                    existingQuestionAnswer.Id = dataWrapper.ExistingQuestions.QuestionsAnswers.First().Id;

                    if (dataWrapper.ExistingQuestions.QuestionsAnswers.First().Id == existingQuestionAnswerSet.QuestionsAnswers.Count)
                    {
                        existingQuestionAnswerSet.QuestionsAnswers.RemoveAt(0);
                        existingQuestionAnswerSet.QuestionsAnswers.Insert(0, existingQuestionAnswer);
                    }
                    else
                    {
                        existingQuestionAnswerSet.QuestionsAnswers.RemoveAt(dataWrapper.ExistingQuestions.QuestionsAnswers.First().Id);
                        existingQuestionAnswerSet.QuestionsAnswers.Insert(dataWrapper.ExistingQuestions.QuestionsAnswers.First().Id, existingQuestionAnswer);
                    }                                        
                }

                dataWrapper.ExistingQuestions = existingQuestionAnswerSet;
                dataWrapper.InterviewXmlFile = dataWrapper.DeveloperLevel;

                taskExecuter = new Action<DataWrapper>(InternalSave);
               return taskExecuter.ExecuteAndHandleAnyErrors<DataWrapper>(dataWrapper);
            }
            return null;
        }

        #endregion
    }
}
