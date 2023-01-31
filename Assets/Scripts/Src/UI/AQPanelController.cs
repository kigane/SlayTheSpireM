using deVoid.UIFramework;
using QFramework;

namespace SlayTheSpireM
{
    public class AQPanelController : APanelController, IController
    {
        public IArchitecture GetArchitecture()
        {
            return SlayTheSpireGame.Interface;
        }
    }
}
