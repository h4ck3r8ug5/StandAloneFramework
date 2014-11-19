﻿using System.IO;
using System.Linq;
using System.Text;
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
            if (!File.Exists(args.Argument))
            {
                using (var fs = new FileStream(args.Argument, FileMode.CreateNew, FileAccess.Write, FileShare.Read))
                {
                    var bytes = Encoding.ASCII.GetBytes(args.xValue.ToString());
                    fs.Write(bytes, 0, bytes.Length);
                    fs.Flush();
                }

                File.Delete(args.Argument);
            }
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
            if (!File.Exists(args.Argument))
            {
                File.Delete(args.Argument);
                using(var fs = new FileStream(args.Argument,FileMode.CreateNew,FileAccess.Write,FileShare.Read))
                {
                    var bytes = Encoding.ASCII.GetBytes(args.xValue.ToString());
                    fs.Write(bytes,0, bytes.Length);
                    fs.Flush();
                }              
            }

            return new InvocationResult
            {
                Data = File.ReadAllText(args.Argument)
            };
        }

        #endregion
    }
}
