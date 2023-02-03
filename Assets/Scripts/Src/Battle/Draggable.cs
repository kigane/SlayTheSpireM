using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace SlayTheSpireM
{
    public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        public Transform parentToReturn;
        private GameObject placeholder;
        private CanvasGroup canvasGroup;
        private float offsetX;
        private float offsetY;
        private RectTransform rectTransform;
        private Vector2 startPoint;
        public GameObject lineUi;

        private void Awake()
        {
            canvasGroup = GetComponent<CanvasGroup>();
            rectTransform = GetComponent<RectTransform>();
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            startPoint = eventData.position;

            // 将屏幕上的点转换为指定RectTransform中的点的世界坐标
            RectTransformUtility.ScreenPointToWorldPointInRectangle(rectTransform, eventData.position, eventData.pressEventCamera, out var mousePos);
            // rectTransform.position是世界坐标
            offsetX = rectTransform.position.x - mousePos.x;
            offsetY = rectTransform.position.y - mousePos.y;

            // 在原地创造一个卡牌占位符
            var cardGO = Resources.Load<GameObject>("Prefabs/Card");
            placeholder = Instantiate(cardGO, transform.parent);
            placeholder.GetComponent<CanvasGroup>().alpha = 0;

            // 将占位符保持在卡牌原位
            // Log.Debug(transform.GetSiblingIndex());
            placeholder.transform.SetSiblingIndex(transform.GetSiblingIndex());

            // 将卡牌拖到特定区域
            parentToReturn = transform.parent;
            transform.SetParent(transform.parent.parent.parent);

            canvasGroup.blocksRaycasts = false;
        }

        public void OnDrag(PointerEventData eventData)
        {
            RectTransformUtility.ScreenPointToWorldPointInRectangle(rectTransform, eventData.position, eventData.pressEventCamera, out var mousePos);
            var targetPos = mousePos;
            targetPos.x += offsetX;
            targetPos.y += offsetY;
            rectTransform.position = targetPos;

            var line = lineUi.GetComponent<Line>();
            lineUi.SetActive(true);
            line.SetStartPoint(startPoint, eventData.pressEventCamera);
            line.SetEndPoint(eventData.position, eventData.pressEventCamera);
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            lineUi.SetActive(false);
            // return;
            List<RaycastResult> raycastResults = new();
            EventSystem.current.RaycastAll(eventData, raycastResults);
            foreach (var item in raycastResults)
            {
                // Log.Debug(item.gameObject.name);
                // Log.Debug(item.screenPosition);
                // Log.Debug(item.sortingLayer);
                if (item.gameObject.name == "Battle Field") // 打出
                {
                    // Log.Debug("Battle Field", item.screenPosition);
                    parentToReturn = null;
                    Destroy(gameObject);
                }
                // if (item.gameObject.name == "Player Image")
                // {
                //     Log.Debug("Player Image", item.screenPosition);
                // }
                // if (item.gameObject.name == "Enemy Image")
                // {
                //     Log.Debug("Enemy Image", item.screenPosition);
                // }
            }

            if (parentToReturn) // 没打出去
            {
                transform.SetParent(parentToReturn);
                canvasGroup.blocksRaycasts = true;
                transform.SetSiblingIndex(placeholder.transform.GetSiblingIndex());
            }
            Destroy(placeholder);
        }
    }
}
