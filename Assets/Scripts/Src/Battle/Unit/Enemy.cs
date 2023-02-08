using System.Collections.Generic;
using QFramework;
using UnityEngine;

namespace SlayTheSpireM
{
    public class Enemy : BattleUnit
    {
        private readonly List<Card> intentions; // 意图
        private Card currIntent;
        public Card CurrIntent => currIntent;

        public Enemy(int id)
        {
            this.id = id;
            intentions = new();
            var configs = SqliteManager.QueryCardConfigByRole(id, false);
            Log.Debug("Enemy Intents", configs);
            foreach (var config in configs)
            {
                intentions.Add(CardFactory.CreateCard(config));
            }
        }

        public void GenerateRandomIntention()
        {
            currIntent = intentions[Random.Range(0, intentions.Count)];
        }

        public void DoAction()
        {
            //TODO 执行意图
            BattleUnit target = currIntent.effect.TargetType == TargetType.Self ? this : BattleSession.instance.player;
            currIntent.Play(target);
        }
    }
}
