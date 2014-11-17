using System;
using StandAloneFramework.Extensions;
using StandAloneFramework.Factories.MethodFactory;

namespace StandAloneFramework
{
    public class CodeContractValidator
    {
        public static void ArgumentCannotBeNull(object argument, string objectFriendlyName)
        {
            if (argument.IsObjectNull())
            {
                throw new Exception(string.Format("Code Contract validation failed: {0} cannot be null",objectFriendlyName));
            }
        }        

        public static void MethodSignatureTypeMatch(MethodReturnType methodReturnType, MethodType methodType)
        {
            if ((methodReturnType != MethodReturnType.Return && methodType == MethodType.Func) || (methodReturnType != MethodReturnType.Void && methodType == MethodType.Action))
            {
                throw new Exception(string.Format("Code Contract validation failed: Return type does not match delegate signature type"));
            }
        }
    }
}
