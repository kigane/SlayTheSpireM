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
            SetText(energyText, $"{BattleSession.instance.player.currEnergy}/{BattleSession.instance.player.maxEnergy}");

            this.RegisterEvent<HandCardsUpdateEvent>(e =>
            {
                // Log.Info(e.GetType().Name);
                var hc = BattleSession.instance.player.handCards;
                Log.Debug(hc);
                var deck = BattleSession.instance.deck;

                // 显示手牌
                int i = 0;
                for (; i < hc.Count; i++)
                {
                    var cardGO = handCards.GetChild(i).gameObject;
                    cardGO.GetComponent<CardInfo>().SetData(deck.GetCardById(hc[i]), i);
                    cardGO.SetActive(true);
                }

                while (i < 10)
                {
                    handCards.GetChild(i).gameObject.SetActive(false);
                    i++;
                }

                SetText(drawPileCountText, BattleSession.instance.player.drawPile.Count);
                SetText(discardPileCountText, BattleSession.instance.player.discardPile.Count);
            });

            BattleSession.instance.player.maxEnergy.Register(val =>
            {
                SetText(energyText, $"{BattleSession.instance.player.currEnergy}/{val}");
            }).UnRegisterWhenGameObjectDestroyed(gameObject);

            BattleSession.instance.player.currEnergy.Register(val =>
            {
                SetText(energyText, $"{val}/{BattleSession.instance.player.maxEnergy}");
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