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

        public Player()
        {
            hp.Value = 80;
            maxHp.Value = 80;
        }

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
        public bool PlayACard(int idxInHand, BattleUnit target)
        {
            Log.Debug("PlayACard", idxInHand + " " + target);
            // 设置Action目标为player。
            target ??= this;
            var deck = BattleSession.instance.deck;
            var card = deck.GetCardById(handCards[idxInHand]);
            if (currEnergy.Value < card.energy)
            {
                Log.Info("Energy is not enough!");
                return false;
            }
            card.effect.Cast(target);
            currEnergy.Value -= card.energy;
            discardPile.Add(handCards[idxInHand]);
            handCards.RemoveAt(idxInHand);
            this.SendEvent<HandCardsUpdateEvent>();
            return true;
        }

        public void DrawCards(int n)
        {
            //FIXME 边缘情况: 抽两张牌，但抽牌堆和弃牌堆总共只有一张牌。
            // 超过手牌上限时，直接将牌放入弃牌堆
            if (n > (10 - handCards.Count))
            {
                int j = n + handCards.Count - 10;
                discardPile.AddRange(drawPile.GetRange(0, j));
                drawPile.RemoveRange(0, j);
                n = Mathf.Max(n - j, 0);
            }

            for (int i = 0; i < n; i++)
            {
                if (drawPile.Count == 0)
                {
                    (drawPile, discardPile) = (discardPile, drawPile);
                    Shuffle();
                    discardPile.Clear();
                }
                handCards.Add(drawPile[0]);
                drawPile.RemoveAt(0);
            }
            this.SendEvent<HandCardsUpdateEvent>();
        }

        public void DiscardHandCards()
        {
            Log.Debug("手牌", handCards);
            discardPile.AddRange(handCards);
            Log.Debug("弃牌堆", discardPile);
            handCards.Clear();
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
            // drawPile[1] = 2;
        }

    }
}
