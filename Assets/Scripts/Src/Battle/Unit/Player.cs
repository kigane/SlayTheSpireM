using QFramework;
using System.Collections.Generic;

namespace SlayTheSpireM
{
    public class Player : BattleUnit
    {
        List<int> drawPile;
        List<int> discardPile;
        List<int> handCards;
        List<int> relics;

        public void PlayACard()
        {
            //TODO 出牌
            //TODO 设置Action目标
        }

        public void DrawCards(int n)
        {
            //TODO 抽牌
        }

        public override void GetDamage(int n)
        {
            throw new System.NotImplementedException();
        }

        public override void GainBlock(int n)
        {
            throw new System.NotImplementedException();
        }

        public override void ApplyBuff(int buffId)
        {
            throw new System.NotImplementedException();
        }
    }
}
