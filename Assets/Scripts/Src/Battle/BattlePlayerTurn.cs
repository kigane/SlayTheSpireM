﻿using UnityEngine;
using QFramework;

namespace SlayTheSpireM
{
    public class BattlePlayerTurn : BattleState
    {
        public override void Enter()
        {
            Log.Info("玩家回合!");
            //TODO 遗物效果结算
            //TODO buff效果结算
            //抽牌
            PlayerData.Instance.DrawCards(5);
            //TODO 显示敌人意图
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
        }
    }
}