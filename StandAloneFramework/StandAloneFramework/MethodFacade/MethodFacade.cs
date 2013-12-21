using StandAloneFramework.Factories.Interfaces;
using StandAloneFramework.Factories.MethodFactory;
using StandAloneFramework.MethodFacade.Interfaces;

namespace StandAloneFramework.MethodFacade
{
    public class MethodFacade : IMethodFacade
    {
        #region Properties

        public IMethodFactory MethodFactory { get; set; }

        #endregion

        public MethodFacade()
        {
            MethodFactory = new MethodFactory();
        }
    }
}
