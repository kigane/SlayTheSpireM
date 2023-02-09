using UnityEngine;
using System;
using System.Collections;

namespace SlayTheSpireM
{
    public class BattleEnemyTurn : BattleState
    {
        public override void Enter()
        {
            BattleSession.instance.EndPlayerTurn();
            BattleSession.instance.CleanAllEnemiesBlock();
            Log.Debug("敌方回合!");
            BattleSession.instance.EnemiesDoIntent();
            BattleSession.instance.EndEnemyTurn();
            // BattleSession.instance.ChangeState(BattleStateType.PlayerTurn);
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
        }
    }
}
