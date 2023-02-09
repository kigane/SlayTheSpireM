using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace SlayTheSpireM
{
    public class CardInfo : MonoBehaviour
    {
        public TextMeshProUGUI index;
        public TextMeshProUGUI energy;
        public TextMeshProUGUI cardName;
        public Image cardFace;
        public TextMeshProUGUI cardType;
        public TextMeshProUGUI cardDesc;
        public Card mCard;

        public void SetData(Card card, int i)
        {
            index.text = "" + i;
            energy.text = "" + card.energy;
            cardName.text = card.name;
            // TODO 卡面图片位置
            // Log.Debug("CardFace", card.spritePath);
            cardFace.sprite = Resources.Load<Sprite>("Icon/Buff/" + card.spritePath);
            cardType.text = "" + card.type;
            cardDesc.text = card.description;
        }
    }
}
