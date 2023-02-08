using UnityEngine;
using QFramework;

namespace SlayTheSpireM
{
    public class BattlePlayerTurn : BattleState
    {
        public override void Enter()
        {
            // 清护甲
            BattleSession.instance.player.block.Value = 0;
            // 显示意图 PlayerTurnStartEvent 处理
            BattleSession.instance.StartPlayerTurn();
            Log.Info("玩家回合!");
            //TODO 遗物效果结算
            //TODO buff效果结算
            //弃当前手牌
            BattleSession.instance.player.DiscardHandCards();
            //抽牌
            BattleSession.instance.player.DrawCards(5);
            BattleSession.instance.player.currEnergy.Value = BattleSession.instance.player.maxEnergy.Value;
            //TODO 显示敌人意图
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
        }
    }
}
