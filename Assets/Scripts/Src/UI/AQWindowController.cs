using deVoid.UIFramework;
using QFramework;

namespace SlayTheSpireM
{
    public class AQWindowController : AWindowController, IController
    {
        public IArchitecture GetArchitecture()
        {
            return SlayTheSpireGame.Interface;
        }
    }
}
