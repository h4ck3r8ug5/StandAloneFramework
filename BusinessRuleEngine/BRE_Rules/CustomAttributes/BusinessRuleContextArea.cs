using System;

namespace BusinessRules.CustomAttributes
{
    /// <summary>
    /// Ensures that the rule belongs to the specfic context area
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class BusinessRuleContextArea : Attribute
    {
        public Base.Enums.BusinessRuleContextArea BusinessContextArea { get; set; }

        public BusinessRuleContextArea(Base.Enums.BusinessRuleContextArea businessRuleContextArea)
        {
            BusinessContextArea = businessRuleContextArea;
        }
    }
}
