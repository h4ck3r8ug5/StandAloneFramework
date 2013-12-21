using System.Data;

namespace Cross.Cutting.Concerns.Common.CommonTypes
{
    public class BusinessRule
    {
        public BusinessRule(int businessRuleId, string businessRuleName,
                            int ruleContextAreaId, int ruleStatusId, int ruleSeverity)
        {
            RuleId = businessRuleId;
            RuleName = businessRuleName;
            RuleContextAreaId = ruleContextAreaId;
            RuleStatusId = ruleStatusId;
            RuleSeverityId = ruleSeverity;
        }

        public BusinessRule()
        {

        }

        public static BusinessRule Converter(DataRow dataRow)
        {
            return new BusinessRule
          (
               dataRow.GetValueOrDefault<int>("RuleId"),
               dataRow.GetValueOrDefault<string>(dataRow.GetValueOrDefault<string>("RuleName")),
               dataRow.GetValueOrDefault<int>("RuleContextAreaId"),
               dataRow.GetValueOrDefault<int>("RuleSeverityId"),
               dataRow.GetValueOrDefault<int>("StatusId")
           );
        }

        public string RuleName { get; set; }
        public int RuleId { get; set; }
        public int RuleContextAreaId { get; set; }
        public int RuleStatusId { get; set; }
        public int RuleSeverityId { get; set; }
    }
}
