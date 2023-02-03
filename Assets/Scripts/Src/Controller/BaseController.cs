using QFramework;

namespace SlayTheSpireM
{
    public abstract class BaseController : IController
    {
        IArchitecture IBelongToArchitecture.GetArchitecture()
        {
            return SlayTheSpireGame.Interface;
        }
    }
}
