using System.Collections.Generic;
using System.Text.RegularExpressions;
using BusinessRules.Base;

namespace BusinessRules
{
    public class CustomBusinessRule<T> : IBusinessRule where T : class
    {
        #region Properties

        public T Instance
        {
            get { return (T)Owner; }
        }

        private IList<RuleValidationMessage> messages;
        protected IList<RuleValidationMessage> Messages
        {
            get
            {
                if (messages == null || messages.Count == 0)
                {
                    messages = new List<RuleValidationMessage>();
                }
                return messages;
            }
        }

        public RuleValidationMessage RuleValidationMessage { get; set; }

        #endregion

        protected CustomBusinessRule()
        {
            RuleValidationMessage = new RuleValidationMessage();
        } 

        #region Interface Members

        public object RuleTarget { get; set; }
        public string RuleValidationMessageText { get; set; }
        public bool IsValid { get; set; }
        public Regex RegularExpressionHandler { get; set; }
        public RuleValidationMessageType RuleValidationMessageType { get { return ((IsValid) ? RuleValidationMessageType.Information : RuleValidationMessageType.Error); } }
        public object Owner { get; set; }
        public virtual void ValidateRule()
        {
            
        }

        #endregion

        #region Methods

        protected virtual IList<RuleValidationMessage> StartValidate()
        {
            return null;
        }

        protected void CreateMessage()
        {
            RuleValidationMessage.ValidationMessage = RuleValidationMessageText;
            RuleValidationMessage.RuleValidationMessageType = RuleValidationMessageType;
        }

        /// <summary>
        /// **** Temporary fix - this will clear the messages list after each unit test has run. Need to redesign the rule engine to cater for this ****
        /// </summary>
        public void ClearMessageList()
        {
            if (messages != null && messages.Count > 0)
            {
                messages.Clear();
            }
        }

        #endregion
    }
}
