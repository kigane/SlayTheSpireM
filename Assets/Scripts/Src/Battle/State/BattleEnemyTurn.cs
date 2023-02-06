﻿using UnityEngine;

namespace SlayTheSpireM
{
    public class BattleEnemyTurn : BattleState
    {
        public override void Enter()
        {
            Log.Debug("敌方回合!");
            BattleSession.instance.ChangeState(BattleStateType.PlayerTurn);
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
        }
    }
}
