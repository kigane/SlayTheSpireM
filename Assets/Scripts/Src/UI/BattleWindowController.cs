using UnityEngine;
using UnityEngine.UI;
using deVoid.UIFramework;
using DG.Tweening;
using TMPro;
using QFramework;

namespace SlayTheSpireM
{
    public class BattleWindowController : AQWindowController
    {
        public Transform handCards;
        public TextMeshProUGUI drawPileCountText;
        public TextMeshProUGUI discardPileCountText;
        public TextMeshProUGUI exhaustedPileCountText;
        public TextMeshProUGUI energyText;

        private IPlayerModel playerModel;

        protected override void AddListeners()
        {// in awake
            playerModel = this.GetModel<IPlayerModel>();
            SetText(drawPileCountText, playerModel.Deck.Count);
            SetText(discardPileCountText, "0");
            SetText(exhaustedPileCountText, "0");
            SetText(energyText, $"{PlayerData.Instance.currEnergy}/{PlayerData.Instance.maxEnergy}");

            this.RegisterEvent<HandCardsUpdateEvent>(e =>
            {
                // Log.Info(e.GetType().Name);
                var hc = PlayerData.Instance.handCards;

                // 显示手牌
                int i = 0;
                for (; i < hc.Count; i++)
                {
                    var cardGO = handCards.GetChild(i).gameObject;
                    cardGO.GetComponent<CardInfo>().SetData(hc[i], i);
                    cardGO.SetActive(true);
                }

                while (i < 10)
                {
                    handCards.GetChild(i).gameObject.SetActive(false);
                    i++;
                }

                SetText(drawPileCountText, PlayerData.Instance.drawPile.Count);
                SetText(discardPileCountText, PlayerData.Instance.discardPile.Count);
            });

            PlayerData.Instance.maxEnergy.Register(val =>
            {
                SetText(energyText, $"{PlayerData.Instance.currEnergy}/{val}");
            }).UnRegisterWhenGameObjectDestroyed(gameObject);

            PlayerData.Instance.currEnergy.Register(val =>
            {
                SetText(energyText, $"{val}/{PlayerData.Instance.maxEnergy}");
            }).UnRegisterWhenGameObjectDestroyed(gameObject);
        }

        private void SetText(TextMeshProUGUI tmp, string content)
        {
            tmp.text = content;
        }

        private void SetText(TextMeshProUGUI tmp, int content)
        {
            tmp.text = "" + content;
        }
    }
}