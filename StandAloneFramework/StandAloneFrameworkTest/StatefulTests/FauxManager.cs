namespace StandAloneFrameworkTest.StatefulTests
{
    public class FauxManager
    {
        protected bool IsMethodIvoked { get; set; }

        protected bool ExpectedFauxCallResult{get { return true; }}

        protected bool ActualFauxCallResult { get; set; }
    }
}
