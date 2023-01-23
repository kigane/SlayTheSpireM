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

        private void Awake()
        {
            image = GetComponent<Image>();
            startX = transform.position.x;
        }

        private void OnEnable()
        {
            image.color = new Color32(0, 0, 0, 0);
            var pos = transform.position;
            pos.x = startX;
            transform.position = pos;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            image.color = new Color32(227, 220, 138, 178);
            transform.DOMoveX(startX + offsetX, moveDuration);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            image.color = new Color32(0, 0, 0, 0);
            transform.DOMoveX(startX, moveDuration);
        }
    }
}
