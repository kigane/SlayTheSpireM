using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening;

namespace SlayTheSpireM
{
    public class ButtonHoverBehavior : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        public float offsetX = 20;
        public float moveDuration = 0.5f;

        private Image image;
        private float startX;
        private RectTransform rt;

        private void Awake()
        {
            image = GetComponent<Image>();
            rt = (RectTransform)transform;
            startX = rt.anchoredPosition.x;
        }

        private void OnEnable()
        {
            image.color = new Color32(0, 0, 0, 0);
            var pos = rt.anchoredPosition;
            pos.x = startX;
            rt.anchoredPosition = pos;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            image.color = new Color32(227, 220, 138, 178);
            // 如果使用transform.DOMoveX()会有bug，使按钮位置不正确。
            rt.DOAnchorPosX(startX + offsetX, moveDuration);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            image.color = new Color32(0, 0, 0, 0);
            rt.DOAnchorPosX(startX, moveDuration);
        }
    }
}
