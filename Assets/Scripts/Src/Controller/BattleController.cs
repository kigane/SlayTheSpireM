using UnityEngine;
using QFramework;
using TMPro;

namespace SlayTheSpireM
{
    public class BattleController : BaseController
    {
        public Transform handCards;
        public TextMeshProUGUI drawPileCountText;
        public TextMeshProUGUI discardPileCountText;
        public TextMeshProUGUI exhaustedPileCountText;
        public TextMeshProUGUI energyText;

        private IPlayerModel playerModel;

        private void Awake()
        {
            playerModel = this.GetModel<IPlayerModel>();
            SetText(drawPileCountText, playerModel.Deck.Count);
            SetText(discardPileCountText, "0");
            SetText(exhaustedPileCountText, "0");
            SetText(energyText, $"{PlayerData.Instance.currEnergy}/{PlayerData.Instance.maxEnergy}");

            this.RegisterEvent<HandCardsUpdateEvent>(e =>
            {
                Log.Info(e.GetType().Name);
                var hc = PlayerData.Instance.handCards;
                // 显示手牌
                int i = 0;
                for (; i < hc.Count; i++)
                {
                    var cardGO = handCards.GetChild(i).gameObject;
                    cardGO.GetComponent<CardInfo>().SetCardInfo(hc[i], i);
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
