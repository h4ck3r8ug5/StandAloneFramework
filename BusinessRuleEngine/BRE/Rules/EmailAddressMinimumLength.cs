using BRE.Base;
namespace BRE.Rules
{
    public sealed class EmailAddressMinimumLength : DefaultMembers
    {
        protected override void Validate(dynamic args)
        {
            var emailAddress = (Account) args;
            IsValid = emailAddress.EmailAddress.Length > 0;
        }

        protected override string Message
        {
            get { return (IsValid) ? "Email address is correct length" : "Email address must be completed"; }
        }
    }
}
