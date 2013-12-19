 using System;
 using StandAloneFramework.FrameworkClasses;

namespace StandAloneFramework.Intefaces
 {
     public interface IDynamicInvoker
     {
         void InvokeMethod<T>(Action<T> methodToInvoke, params object[] args);

         InvocationResult InvokeMethod<T>(Func<T, InvocationResult> methodToInvoke, params object[] args);
     }
 }