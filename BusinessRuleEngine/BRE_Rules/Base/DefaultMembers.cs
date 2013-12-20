using System;
using System.Text.RegularExpressions;

namespace BusinessRules.Base
{
    public class DefaultMembers<T>
    {
        private T ruleDomainContext;

        public virtual T RuleDomainContext
        {
            get
            {
                if(ruleDomainContext == null)
                {
                    ruleDomainContext = Activator.CreateInstance<T>();
                    return ruleDomainContext;
                }
                return ruleDomainContext;
            }
        }

        public virtual string Message { get; protected set; }
        public bool IsValid { get; set; }
        public virtual void Validate(){}
        public string MessageCode
        {
            get
            {
                return (IsValid) ? MessageType.MessageTypes.Information.ToString() : MessageType.MessageTypes.Error.ToString();
            }
        }
        protected Regex RegularExpressionHandler;
    }
}

