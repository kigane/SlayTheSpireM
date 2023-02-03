using UnityEngine;
using QFramework;

namespace SlayTheSpireM
{
    public class BattleState
    {
        public virtual void Enter() { }

        public virtual void OnUpdate() { }

        // public IArchitecture GetArchitecture()
        // {
        //     return SlayTheSpireGame.Interface;
        // }
    }
}
