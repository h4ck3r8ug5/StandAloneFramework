 using System;
 using StandAloneFramework.Factories.MethodFactory;
 using StandAloneFramework.FrameworkClasses;

namespace StandAloneFramework.Intefaces
 {
     public interface IDynamicInvoker
     {
         InvocationResult InvokeMethod(MethodWrapper methodWrapper);
     }
 }