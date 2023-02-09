using UnityEngine;
using QFramework;

namespace SlayTheSpireM
{
    public class BattleState : ICanSendCommand
    {
        public virtual void Enter() { }

        public virtual void OnUpdate() { }

        public IArchitecture GetArchitecture()
        {
            return SlayTheSpireGame.Interface;
        }
    }
}
