using QFramework;
using System.Collections.Generic;
using UnityEngine;

namespace SlayTheSpireM
{
    public class PlayerData : IController
    {
        private PlayerData() { }
        private static PlayerData instance;
        public static PlayerData Instance
        {
            get
            {
                instance ??= new PlayerData();
                return instance;
            }
        }

        public List<Card> drawPile;
        public List<Card> handCards;
        public List<Card> discardPile;
        public BindableProperty<int> currEnergy = new(3);
        public BindableProperty<int> maxEnergy = new(3);
        public BindableProperty<int> drawCardsPerTurn = new(5);

        public void SetDeck(List<Card> playerDeck)
        {
            drawPile = new();
            discardPile = new();
            handCards = new();

            foreach (var card in playerDeck)
            {
                drawPile.Add(new Card(card));
            }
        }

        public void DrawCards(int n)
        {
            //TODO 超过手牌上限时，直接将牌放入弃牌堆
            for (int i = 0; i < n; i++)
            {
                DrawACard();
            }
            this.SendCommand<UpdateHandCardsViewCommand>();
        }

        public void DrawACard()
        {
            handCards.Add(drawPile[0]);
            drawPile.RemoveAt(0);
        }

        public void UseEnergy(int n)
        {
            currEnergy.Value -= n;
        }

        public void GetEnergy(int n)
        {
            currEnergy.Value += n;
        }

        public void Shuffle()
        {
            int idx;
            for (int i = 0; i < drawPile.Count; i++)
            {
                idx = Random.Range(i, drawPile.Count);
                Helper.Swap(drawPile, i, idx);
            }

            for (int i = 0; i < drawPile.Count; i++)
            {
                Log.Debug(drawPile[i]);
            }
        }

        public IArchitecture GetArchitecture()
        {
            return SlayTheSpireGame.Interface;
        }
    }
}
