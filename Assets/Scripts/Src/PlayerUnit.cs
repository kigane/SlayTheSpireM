using UnityEngine;
using QFramework;

namespace SlayTheSpireM
{
    public class PlayerUnit : BaseUnit
    {
        private IPlayerModel playerModel;

        private void Awake()
        {
            playerModel = this.GetModel<IPlayerModel>();
            // 血条功能
            playerModel.Hp.Register(val =>
            {
                SetHealthSlider((float)val / playerModel.MaxHp.Value);
            }).UnRegisterWhenGameObjectDestroyed(gameObject);

            playerModel.MaxHp.Register(val =>
            {
                SetHealthSlider((float)playerModel.Hp.Value / val);
            }).UnRegisterWhenGameObjectDestroyed(gameObject);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.J))
            {
                playerModel.Hp.Value -= 10;
            }

            if (Input.GetKeyDown(KeyCode.K))
            {
                AddBuff(new Buff("attack", BuffType.NUMBER, 0, 1));
            }

            if (Input.GetKeyDown(KeyCode.L))
            {
                AddBuff(new Buff("buff", BuffType.EFFECT, 1, 0));
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                PlayerData.Instance.DrawCards(2);
            }

            if (Input.GetKeyDown(KeyCode.V))
            {
                PlayerData.Instance.discardPile.Add(PlayerData.Instance.handCards[3]);
                PlayerData.Instance.handCards.RemoveAt(3);
                this.SendCommand<UpdateHandCardsViewCommand>();
            }
        }
    }
}
