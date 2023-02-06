using UnityEngine;
using TMPro;
using DG.Tweening;

namespace SlayTheSpireM
{
    public class FloatingText : MonoBehaviour
    {
        TextMeshProUGUI text;
        RectTransform rectTransform;

        private void Awake()
        {
            text = GetComponentInChildren<TextMeshProUGUI>();
            rectTransform = GetComponent<RectTransform>();
        }

        public void ShowFloatingText(string content, Transform transform)
        {
            gameObject.SetActive(true);
            text.text = content;
            // rectTransform的旋转只会旋转Rect对象，不会实际旋转Rect内的文字。
            // text.transform.eulerAngles = new Vector3(0, 0, -90f);
            Vector2 screenPos = Camera.main.WorldToScreenPoint(transform.position);
            screenPos += new Vector2(0, 50);
            RectTransformUtility.ScreenPointToWorldPointInRectangle(rectTransform, screenPos, Camera.main, out var worldPos);
            // 两者等价
            // Log.Debug("World Pos", worldPos); 
            // Log.Debug("Transform.position", transform.position);
            transform.DOMoveY(worldPos.y, 0.7f).OnComplete(() =>
            {
                Destroy(gameObject);
            });
        }
    }
}
