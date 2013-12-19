namespace StandAloneFramework.Extensions
{
    public static class FauxExtensions
    {
        public static dynamic CallResult(this object target)
        {
            return target.IsObjectNotNull();
        }
    }
}
