using System.Collections.Generic;
using BusinessRules.Base;
using BusinessRules.Base.Enums;

namespace BusinessRuleEngine.Base
{
    /// <summary>
    /// Acts as the Base that the validation engine inherits from
    /// </summary>
    public class BaseValidationContext
    {
        #region Properties

        /// <summary>
        /// Gets or Sets the collection of valid rules and non valid rules
        /// </summary>
        /// <value>The rules.</value>
        protected Dictionary<object, object> Rules { get; set; }

        protected BaseValidationContext()
        {
            Rules = new Dictionary<object, object>();
            Cache = new HashSet<object>();
        }

        /// <summary>
        /// Gets or sets the business rule cache.
        /// </summary>
        /// <value>The business rule cache.</value>
        protected HashSet<object> Cache { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Executes the rule
        /// </summary>
        /// <param name="rule">The business rule to execute</param>        
        protected RuleValidationMessage ExecuteRule(dynamic rule)
        {
            rule.ValidateRule();
            return rule.Notification;
        }

        /// <summary>
        /// Creates the rule bag containing all the rules
        /// </summary>
        /// <param name="instance">The instance that will be tested against the rules</param>
        /// <param name="businessRuleContextArea">The content area in which the rules belong to</param>
        protected RuleValidationMessage CreateRuleBag(object instance, BusinessRuleContextArea businessRuleContextArea)
        {
            var ruleFactory = new RuleCollection();
            ruleFactory.BusinessRuleCache.Clear();
            
            IsFirstRun = true;

            ruleFactory.ResolveRules(instance, businessRuleContextArea);
            if (ruleFactory.BusinessRuleCache.Count > 0)
            {
                Rules = ruleFactory.BusinessRuleCache;
            }
                    
            return null;
        }

        public bool IsFirstRun { get; set; }

        #endregion
    }
}
