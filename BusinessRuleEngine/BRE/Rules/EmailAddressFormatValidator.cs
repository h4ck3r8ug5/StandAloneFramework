using System.Text.RegularExpressions;

namespace BRE.Rules
{
    public sealed class EmailAddressFormatValidator:  Base.DefaultMembers
    {
       
        protected override string Message
        {
            get { return (IsValid) ? "Email address format is correct" : "Email address format is incorrect"; }
            set { }
        }

        protected  override void Validate(dynamic args)
        {
            const string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                                    @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                                    @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
            IsValid = Regex.IsMatch(args.ToString(), strRegex);
        }
    }
}
