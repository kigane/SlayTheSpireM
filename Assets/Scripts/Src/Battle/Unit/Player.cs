using QFramework;
using System.Collections.Generic;
using UnityEngine;

namespace SlayTheSpireM
{
    public class Player : BattleUnit
    {
        public List<int> drawPile = new();
        public List<int> discardPile = new();
        public List<int> handCards = new();
        public List<int> relics = new();
        public BindableProperty<int> currEnergy = new(3);
        public BindableProperty<int> maxEnergy = new(3);
        public BindableProperty<int> playerHp = new(80);
        public BindableProperty<int> playerMaxHp = new(80);
        public BindableProperty<int> playerBlock = new(0);

        public void SetUp()
        {
            currEnergy.Value = maxEnergy.Value;
            ResetDeck();
            Shuffle();
        }

        public void ResetDeck()
        {
            var deck = BattleSession.instance.deck;
            drawPile = new List<int>(deck.deck);
            discardPile.Clear();
            handCards.Clear();
        }

        // 出牌
        public void PlayACard(int idxInHand, BattleUnit target)
        {
            // 设置Action目标为player。
            target ??= this;
            var deck = BattleSession.instance.deck;
            var card = deck.GetCardById(handCards[idxInHand]);
            card.effect.Cast(target);
            discardPile.Add(handCards[idxInHand]);
            handCards.RemoveAt(idxInHand);
            this.SendEvent<HandCardsUpdateEvent>();
        }

        public void DrawCards(int n)
        {
            //TODO 超过手牌上限时，直接将牌放入弃牌堆
            for (int i = 0; i < n; i++)
            {
                handCards.Add(drawPile[0]);
                drawPile.RemoveAt(0);
            }
            this.SendEvent<HandCardsUpdateEvent>();
        }

        public void Shuffle()
        {
            int idx;
            for (int i = 0; i < drawPile.Count; i++)
            {
                idx = Random.Range(i, drawPile.Count);
                Helper.Swap(drawPile, i, idx);
            }
            //FIXME 需要移除的移除测试代码
            drawPile[1] = 2;
        }

        public override void GetDamage(int n)
        {
            playerHp.Value -= n;
        }

        public override void GainBlock(int n)
        {
            playerBlock.Value += n;
            Log.Debug(playerBlock.Value);
        }
    }
}
