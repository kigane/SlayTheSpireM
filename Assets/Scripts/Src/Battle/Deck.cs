﻿using QFramework;
using System.Collections.Generic;
using System;

namespace SlayTheSpireM
{
    public class Deck : BaseController
    {
        public List<int> deck = new();
        public Dictionary<int, Card> DeckCardsCache = new();

        public Deck(RoleType role)
        {
            if (role == RoleType.IRONCLAD)
            {
                deck.Add(0);
                deck.Add(0);
                deck.Add(0);
                deck.Add(0);
                deck.Add(0);
                deck.Add(1);
                deck.Add(1);
                deck.Add(1);
                deck.Add(1);
                deck.Add(1);
                deck.Add(2);
            }
            else
            {
                throw new NotImplementedException("现在只有战士哥");
            }

            var cardConfigModel = this.GetModel<CardConfigModel>();
            var roleCardConfigs = cardConfigModel.GetCardsByRole(role);
            var allRoleCardConfigs = cardConfigModel.GetCardsByRole(RoleType.ALL);
            foreach (var cardConfig in roleCardConfigs)
            {
                DeckCardsCache[cardConfig.Id] = CardFactory.CreateCard(cardConfig);
            }
            foreach (var cardConfig in allRoleCardConfigs)
            {
                DeckCardsCache[cardConfig.Id] = CardFactory.CreateCard(cardConfig);
            }
            Log.Debug(DeckCardsCache);
        }

        public Card GetCardById(int id)
        {
            return DeckCardsCache[id];
        }
    }
}
