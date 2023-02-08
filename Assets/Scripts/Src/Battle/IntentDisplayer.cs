using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace SlayTheSpireM
{
    public class IntentDisplayer : MonoBehaviour
    {
        [SerializeField] Image icon;
        [SerializeField]
        TextMeshProUGUI value;

        public void SetData(Card card)
        {
            Log.Debug(card);
            icon.sprite = Resources.Load<Sprite>("Icon/Intent/" + card.spritePath);
            value.text = card.effect.Value.ToString();
        }
    }
}
