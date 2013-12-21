using System;
using StandAloneFramework.Extensions;

namespace StandAloneFramework
{
    public static class CodeContractValidator
    {
        public static void ArgumentCannotBeNull(object argument, string objectFriendlyName)
        {
            if (argument.IsObjectNull())
            {
                throw new Exception(string.Format("Code Contract validation failed: {0} cannot be null",objectFriendlyName));
            }
        }
    }
}
