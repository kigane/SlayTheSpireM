using UnityEngine;
using QFramework;

namespace SlayTheSpireM
{
    public abstract class BaseMonoController : MonoBehaviour, IController
    {
        IArchitecture IBelongToArchitecture.GetArchitecture()
        {
            return SlayTheSpireGame.Interface;
        }
    }
}
