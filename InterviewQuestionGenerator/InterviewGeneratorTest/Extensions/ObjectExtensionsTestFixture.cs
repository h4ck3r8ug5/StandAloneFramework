using System;
using System.Collections.Generic;
using System.Text;
using InterviewGeneratorFramework.Classes;
using InterviewGeneratorFramework.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InterviewGeneratorTest.Extensions
{
    [TestClass]
    public class ObjectExtensionsTestFixture
    {
        [TestMethod]
        public void ObjectIsNotNullTest()
        {
            var source = new DataWrapper();

            var actual = source.IsObjectNotNull();

            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void ObjectIsNullTest()
        {
            object source = null;

            var actual = source.IsObjectNull();

            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void DeSerializeToObjectTest()
        {
            const string targetObjectString = @"<QuestionAnswerSet></QuestionAnswerSet>";

            var expected = new QuestionAnswerSet();
            var actual = targetObjectString.DeserializeObject<QuestionAnswerSet>();

            Assert.AreEqual(expected,actual);
        }

        [TestMethod]
        public void SerializeToObjectTest()
        {
            const string targetObjectString = @"<QuestionAnswerSet>
                          <QuestionsAnswers />
                        </QuestionAnswerSet>";

            var bytes = Encoding.ASCII.GetBytes(targetObjectString);                        

            var source = new QuestionAnswerSet
            {
                QuestionsAnswers = new List<LocalQuestionAnswer>()
            };

            var actual = source.SerializeObject<QuestionAnswerSet>().ConvertToEncodingType(Encoding.ASCII);

            var expected = Encoding.ASCII.GetString(bytes);

            Assert.AreEqual(expected.ConvertToEncodingType(Encoding.ASCII), actual);
        }
    }
}
