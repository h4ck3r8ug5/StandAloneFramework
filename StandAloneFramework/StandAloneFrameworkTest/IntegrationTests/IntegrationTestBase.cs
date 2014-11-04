using System;
using System.IO;
using System.Linq;
using StandAloneFramework;
using StandAloneFramework.FrameworkClasses;
using StandAloneFramework.MethodFacade;

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
        #region Action Methods

        internal static void WriteTextFile(DataWrapper args)
        {
            File.WriteAllText(args.Argument,"Testing the file");
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
                Data = File.ReadAllText(args.Argument);
            };
        }

        #endregion
    }
}
