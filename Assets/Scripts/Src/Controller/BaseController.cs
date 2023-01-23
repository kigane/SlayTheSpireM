using UnityEngine;
using QFramework;

namespace SlayTheSpireM
{
    public abstract class BaseController : MonoBehaviour, IController
    {
        IArchitecture IBelongToArchitecture.GetArchitecture()
        {
            return SlayTheSpireGame.Interface;
        }
    }
}
