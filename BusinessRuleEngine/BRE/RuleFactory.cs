using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using BusinessRules.Base;
using BusinessRules.CustomAttributes;

namespace BusinessRuleEngine
{
    /// <summary>
    /// Manages the creation of the business rules
    /// </summary>
    public class RuleCollection
    {
        /// <summary>
        /// Gets or sets the business rule cache.
        /// </summary>
        /// <value>
        /// The business rule cache.
        /// </value>
        public Dictionary<object, object> BusinessRuleCache { get; set; }

        private bool isFirstRun;

        /// <summary>
        /// Initializes a new instance of the <see cref="RuleCollection" /> class.
        /// </summary>
        public RuleCollection()
        {
            isFirstRun = true;
            BusinessRuleCache = new Dictionary<object, object>();
        }

        /// <summary>
        /// Resolves the rules.
        /// </summary>
        /// <param name="instance">The instance.</param>
        /// <param name="businessRuleContextArea">The context area.</param>       
        public void ResolveRules(object instance, BusinessRules.Base.Enums.BusinessRuleContextArea businessRuleContextArea)
        {
            try
            {
                var loadedAssembly = Assembly.Load("88Symmetry.BusinessRules");

                var businessRuleDomainRules = loadedAssembly.GetTypes().Where(rule => rule.Namespace == "BusinessRules." +
                                                                   businessRuleContextArea && rule.IsClass);

                foreach (var businessRule in businessRuleDomainRules)
                {
                    var ruleInstance = (IBusinessRule)Activator.CreateInstance(businessRule);

                    ruleInstance.Owner = instance;
                    ruleInstance.RuleTarget = instance;

                    foreach (var customAttribute in businessRule.GetCustomAttributes(false))
                    {
                        #region Check if the custom attribute is of type BusinessRuleContextArea

                        var customRuleDomainCustomAttribute = customAttribute as BusinessRuleContextArea;

                        if (customRuleDomainCustomAttribute!= null  &&
                            customRuleDomainCustomAttribute.BusinessContextArea == businessRuleContextArea)
                        {
                            var cachedBusinessRule = BusinessRuleCache.FirstOrDefault(x=>x.GetHashCode() == ruleInstance.GetHashCode());
                            if (cachedBusinessRule.Key != null)
                            {
                                BusinessRuleCache.Add(ruleInstance,null);
                            }
                        }

                        #endregion
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
