using System.Collections.Generic;
using System.Linq;
using BusinessRuleEngine.Base;
using BusinessRules.Base;
using BusinessRules.Base.Enums;

namespace BusinessRuleEngine
{
    /// <summary>
    /// Manages the methods that Execute the rules against the given instance per context area
    /// </summary>
    public class ValidateRules : BaseValidationContext
    {
        /// <summary>
        /// Executes the rules against the given instance per context area and returns a collection of Messages based on the execution result of the rules
        /// </summary>
        /// <param name="instance">The target object that the rules will run against</param>
        /// <param name="businessRuleContextArea">The context area that the target belongs to</param>
        /// <returns>IList{CommonTypes.Message}.</returns>
        public IList<RuleValidationMessage> ExecuteRules(object instance, BusinessRuleContextArea businessRuleContextArea)
        {
            CreateRuleBag(instance, businessRuleContextArea);

            return Rules.Keys.Select(ExecuteRule).ToList();
        }
    }
}
