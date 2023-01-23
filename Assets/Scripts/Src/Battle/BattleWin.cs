using UnityEngine;

namespace SlayTheSpireM
{
    public class BattleWin : BattleState
    {
        public override void Enter()
        {
            Log.Debug("战斗胜利!");
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
        }
    }
}
