namespace BusinessRules.Base
{
    public class BaseContext
    {
        public enum RuleContext
        {
            AccountEmailAddress,            
        }

        public Account CreateAccount()
        {
            return new Account
                       {
                           EmailAddress = "sokka.sta@gmail.com",
                           Name = "Charles Trent"
                       };
        }
    }

    public struct Account
    {
        public string Name { get; set; }
        public string EmailAddress { get; set; }
    }
}
