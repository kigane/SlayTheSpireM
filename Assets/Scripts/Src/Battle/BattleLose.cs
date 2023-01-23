using UnityEngine;

namespace SlayTheSpireM
{
    public class BattleLose : BattleState
    {
        public override void Enter()
        {
            Log.Debug("战斗失败!");
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
        }
    }
}
