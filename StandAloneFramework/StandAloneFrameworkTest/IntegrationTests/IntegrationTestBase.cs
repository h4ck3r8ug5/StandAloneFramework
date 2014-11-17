using System.IO;
using System.Linq;
using StandAloneFramework;
using StandAloneFramework.FrameworkClasses;
using StandAloneFramework.MethodFacade;
using StandAloneFrameworkTest.ServiceReference1;

namespace StandAloneFrameworkTest.IntegrationTests
{
    public class IntegrationTestBase
    {
        #region Properties

        protected MethodFacade MethodFacade { get; set; }

        protected DataWrapper DataWrapper { get; set; }

#endregion
    }

    public class TestFixtureMethods
    {
        private static readonly DummyServiceClient dummyServiceClient;

        static TestFixtureMethods()
        {
            dummyServiceClient = new DummyServiceClient();
        }

        #region Action Methods

        internal static void WriteTextFile(DataWrapper args)
        {
            File.WriteAllText(args.Argument,"Testing the file");
        }

        internal static void WriteDataToDatabase(DataWrapper args)
        {
            dummyServiceClient.SaveDatabaseRecord("charles","trent123");
        }

        internal static InvocationResult ReadDataFromDatabase(DataWrapper args)
        {
            var result = dummyServiceClient.GetDatabaseRecord(args.Argument);
            return new InvocationResult
            {
                Data = result,
                MessageType = InvocationResult.InvocationResultType.Success
            };
        }

        #endregion

        #region Func<> Methods

        internal static InvocationResult AddNums(DataWrapper args)
        {
            return new InvocationResult
            {
                Data = Enumerable.Range(0,args.xValue).Sum().ToString()
            };
        }

        internal static InvocationResult ReadTextFile(DataWrapper args)
        {
            return new InvocationResult
            {
                Data = File.ReadAllText(args.Argument)
            };
        }

        #endregion
    }
}
