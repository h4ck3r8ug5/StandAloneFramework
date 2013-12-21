using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using BusinessRules.Base.Enums;

namespace BusinessRules
{
    //namespace UserAccount
    //{
    //    [CustomAttributes.BusinessRuleContextArea(BusinessRuleContextArea.UserAccount)]
    //    public class UserIdNumberMustBeValid : CustomBusinessRule<Cross.Cutting.Concerns.Common.DataTransferObjects.ApplicationUser>
    //    {
    //        public override void ValidateRule()
    //        {
    //            var isIdNumberValid = CheckIDNumber(Instance.UserAccountDTO.IdNumber.ToString());
    //            if (!isIdNumberValid)
    //            {
    //                NotificationMessage = "The ID number is invalid.";
    //                IsValid = false;
    //                CreateMessage();
    //            }
    //            else
    //            {
    //                IsValid = true;
    //            }
    //        }

    //        private static bool CheckIDNumber(string idNumber)
    //        {
    //            if (idNumber.Length > 13 || idNumber.Length < 13)
    //            {
    //                return false;
    //            }

    //            var oddNumberIndexTotalList = new List<int>();
    //            for (var i = 0; i < 10; i += 2)
    //            {
    //                {
    //                    oddNumberIndexTotalList.Add(int.Parse(idNumber[i].ToString()));
    //                }
    //            }

    //            var oddNumberIndexTotal = oddNumberIndexTotalList.Sum();

    //            var evenNumberList = new List<int>();
    //            for (var i = 0; i < idNumber.Length; i++)
    //            {
    //                evenNumberList.Add(Convert.ToInt32(idNumber[i].ToString()));
    //            }

    //            var tempList = new List<int>();
    //            for (var i = 1; i < evenNumberList.Count - 1; i += 2)
    //            {
    //                tempList.Add(evenNumberList[i]);
    //            }

    //            var evenNumberIndexTotalTemp = (long.Parse(string.Join("", tempList.ToArray())) * 2).ToString();
    //            var evenNumberIndexTotal = new List<int>();
    //            for (var i = 0; i < evenNumberIndexTotalTemp.Length; i++)
    //            {
    //                evenNumberIndexTotal.Add(int.Parse(evenNumberIndexTotalTemp[i].ToString()));
    //            }

    //            var step3SumEvenIndex = evenNumberIndexTotal.Sum();

    //            var finalStep = oddNumberIndexTotal + step3SumEvenIndex;

    //            var idNumberLastDigit = idNumber.Substring(idNumber.Length - 1);
    //            var currentControlDigit = int.Parse(finalStep.ToString().Substring(1, 1));
    //            var actualControlDigit = 10 - currentControlDigit;

    //            return (int.Parse(idNumberLastDigit) == actualControlDigit);
    //        }
    //    }

    //    [CustomAttributes.BusinessRuleContextArea(Enums.BusinessRuleContextArea.UserAccount)]
    //    public class UserPasswordCannotBeBlank : CustomBusinessRule<Cross.Cutting.Concerns.Common.DataTransferObjects.ApplicationUser>
    //    {
    //        public override void ValidateRule()
    //        {
    //            if (string.IsNullOrEmpty(Instance.Login.PasswordHash))
    //            {
    //                NotificationMessage = "The password cannot be blank.";
    //                IsValid = false;
    //                CreateMessage();
    //            }
    //            else
    //            {
    //                IsValid = true;
    //            }
    //        }
    //    }

    //    [CustomAttributes.BusinessRuleContextArea(Enums.BusinessRuleContextArea.UserAccount)]
    //    public class UserPasswordMustContainUppercaseLetter : CustomBusinessRule<Cross.Cutting.Concerns.Common.DataTransferObjects.ApplicationUser>
    //    {
    //        public override void ValidateRule()
    //        {
    //            var isValid = Instance.Login.PasswordHash.Any(char.IsUpper);
    //            if (!isValid)
    //            {
    //                NotificationMessage = "The password must contain atleast one uppercase character";
    //                IsValid = false;
    //                CreateMessage();
    //            }
    //            else
    //            {
    //                IsValid = true;
    //            }
    //        }
    //    }

    //    [CustomAttributes.BusinessRuleContextArea(Enums.BusinessRuleContextArea.UserAccount)]
    //    public class UserEmailAddressFormatMustBeValid : CustomBusinessRule<Cross.Cutting.Concerns.Common.DataTransferObjects.ApplicationUser>
    //    {
    //        public override void ValidateRule()
    //        {
    //            var regex = new Regex(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
    //            if (!regex.IsMatch(Instance.UserAccountDTO.EmailAddress))
    //            {
    //                IsValid = false;
    //                NotificationMessage = "The user's email address is invalid. Please check the format";
    //                CreateMessage();
    //            }
    //            else
    //            {
    //                IsValid = true;
    //            }
    //        }
    //    }
    //}

    //namespace SupplierLookupData
    //{
    //    [CustomAttributes.BusinessRuleContextArea(Enums.BusinessRuleContextArea.SupplierLookupData)]
    //    public class SupplierVATNumberFormatMustBeCorrect : CustomBusinessRule<Cross.Cutting.Concerns.Common.DataTransferObjects.SupplierLookupDTO>
    //    {
    //        public override void ValidateRule()
    //        {
    //            RegularExpressionHandler = new Regex(@"((19|20)[\d]{2}/[\d]{6}/[\d]{2})");
    //            if (RegularExpressionHandler.IsMatch(Instance.VATNumber))
    //            {
    //                NotificationMessage = "The VAT Number is incorrect. Please check the format.";
    //                IsValid = false;
    //                CreateMessage();
    //            }
    //            else
    //            {
    //                IsValid = true;
    //            }
    //        }
    //    }
    //}

    //namespace FinancialInstitutionLookupData
    //{
    //    [CustomAttributes.BusinessRuleContextArea(Enums.BusinessRuleContextArea.FinancialInstitutionLookupData)]
    //    public class FinancialInstitutionSwiftCodeMustContainDigitsOnly : CustomBusinessRule<Cross.Cutting.Concerns.Common.DataTransferObjects.FinancialInsitutionLookupDTO>
    //    {
    //        public override void ValidateRule()
    //        {
    //            if (string.IsNullOrEmpty(Instance.SwiftCode))
    //            {
    //                NotificationMessage = "The swift code cannot be blank.";
    //                IsValid = false;
    //                CreateMessage();
    //            }
    //            else
    //            {
    //                IsValid = true; 
    //            }
    //        }
    //    }
    //}

    //namespace QualificationLookupData
    //{
    //    [CustomAttributes.BusinessRuleContextArea(BusinessRuleContextArea.QualificationLookupData)]
    //    public class QualificationNameCannotBeBlank : CustomBusinessRule<Cross.Cutting.Concerns.Common.DataTransferObjects.QualificationLookupDTO>
    //    {
    //        public override void ValidateRule()
    //        {
    //            if (string.IsNullOrEmpty(Instance.Name))
    //            {
    //                NotificationMessage = "The name cannot be blank.";
    //                IsValid = false;
    //                CreateMessage();
    //            }
    //            else
    //            {
    //                IsValid = true;
    //            }
    //        }
    //    }
    //}

    //namespace Options
    //{
    //    [CustomAttributes.BusinessRuleContextArea(Enums.BusinessRuleContextArea.Options)]
    //    public class SupplierVATNumberFormatMustBeCorrect : CustomBusinessRule<Cross.Cutting.Concerns.Common.DataTransferObjects.OptionsDTO>
    //    {
    //        public override void ValidateRule()
    //        {
    //            //RegularExpressionHandler = new Regex(@"((19|20)[\d]{2}/[\d]{6}/[\d]{2})");
    //            //if (RegularExpressionHandler.IsMatch(Instance.VATNumber))
    //            //{
    //            //    NotificationMessage = "The VAT Number is incorrect. Please check the format.";
    //            //    IsValid = false;
    //            //    CreateMessage();
    //            //}
    //            //else
    //            //{
    //            //    IsValid = true;
    //            //}
    //            IsValid = true;
    //        }
    //    }
    //}
}