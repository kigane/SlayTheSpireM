using UnityEngine;
using QFramework;
using TMPro;

namespace SlayTheSpireM
{
    public class PlayerUnitController : BaseUnitController
    {
        [SerializeField] GameObject blockGO;
        [SerializeField] TextMeshProUGUI blockNumberText;

        private void Awake()
        {
            BattleSession.instance.player.view = this;
            // 血条功能
            BattleSession.instance.player.hp.Register(val =>
            {
                if (val <= 0)
                {
                    // Game Over
                    this.SendCommand<GameOverCommand>();
                }
                SetHealthSlider((float)val / BattleSession.instance.player.maxHp.Value);
            }).UnRegisterWhenGameObjectDestroyed(gameObject);

            BattleSession.instance.player.maxHp.Register(val =>
            {
                SetHealthSlider((float)BattleSession.instance.player.hp.Value / val);
            }).UnRegisterWhenGameObjectDestroyed(gameObject);

            BattleSession.instance.player.block.Register(val =>
            {
                if (val > 0)
                {
                    blockGO.SetActive(true);
                    blockNumberText.text = val.ToString();
                }
                else
                {
                    blockGO.SetActive(false);
                }
            }).UnRegisterWhenGameObjectDestroyed(gameObject);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.J))
            {
                BattleSession.instance.player.hp.Value -= 10;
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
