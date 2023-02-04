using UnityEngine;
using QFramework;

namespace SlayTheSpireM
{
    public class PlayerUnit : BaseUnit
    {
        private void Awake()
        {
            // 血条功能
            BattleSession.instance.player.playerHp.Register(val =>
            {
                SetHealthSlider((float)val / BattleSession.instance.player.playerMaxHp.Value);
            }).UnRegisterWhenGameObjectDestroyed(gameObject);

            BattleSession.instance.player.playerMaxHp.Register(val =>
            {
                SetHealthSlider((float)BattleSession.instance.player.playerHp.Value / val);
            }).UnRegisterWhenGameObjectDestroyed(gameObject);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.J))
            {
                BattleSession.instance.player.playerHp.Value -= 10;
            }

            if (Input.GetKeyDown(KeyCode.K))
            {
                AddBuff(new Buff("attack", BuffType.AllBattle, 1));
            }

            if (Input.GetKeyDown(KeyCode.L))
            {
                AddBuff(new Buff("buff", BuffType.LastTurns, 1));
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                BattleSession.instance.player.DrawCards(2);
            }

            if (Input.GetKeyDown(KeyCode.V))
            {
                BattleSession.instance.player.discardPile.Add(BattleSession.instance.player.handCards[3]);
                BattleSession.instance.player.handCards.RemoveAt(3);
                this.SendCommand<UpdateHandCardsViewCommand>();
            }
        }
    }
}
