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

        public void SetCardInfo(Card card, int i)
        {
            index.text = "" + i;
            energy.text = "" + card.energy;
            cardName.text = card.name;
            cardFace.sprite = Resources.Load<Sprite>("Icon/Buff/attack");
            cardType.text = "" + card.type;
            cardDesc.text = card.effect;
        }
    }
}
