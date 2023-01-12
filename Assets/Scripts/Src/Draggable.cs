using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace SlayTheSpireM
{
    public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        public Transform parentToReturn;
        public Transform placeholderParent;
        private GameObject placeholder;
        private CanvasGroup canvasGroup;
        private float offsetX;
        private float offsetY;

        private void Awake()
        {
            canvasGroup = GetComponent<CanvasGroup>();
            placeholderParent = transform.parent;
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            // Log.Debug("On drag begin!");
            offsetX = transform.position.x - eventData.position.x;
            offsetY = transform.position.y - eventData.position.y;

            // 在原地创造一个卡牌占位符
            var cardGO = Resources.Load<GameObject>("Prefabs/Card");
            placeholder = Instantiate(cardGO, transform.parent);
            placeholder.GetComponent<CanvasGroup>().alpha = 0;

            // 将占位符保持在卡牌原位
            // Log.Debug(transform.GetSiblingIndex());
            placeholder.transform.SetSiblingIndex(transform.GetSiblingIndex());

            // 将卡牌拖到特定区域
            parentToReturn = transform.parent;
            transform.SetParent(transform.root); // root指向当前GO所在层级的最高层级的GO，这里是Canvas。

            canvasGroup.blocksRaycasts = false;
        }

        public void OnDrag(PointerEventData eventData)
        {
            // Log.Debug("On drag!");
            var targetPos = eventData.position;
            targetPos.x += offsetX;
            targetPos.y += offsetY;
            transform.position = targetPos;

            if (placeholder.transform.parent != placeholderParent)
                placeholder.transform.SetParent(placeholderParent);

            // 卡牌排序
            var neighborIdx = placeholder.transform.GetSiblingIndex();
            for (int i = 0; i < placeholderParent.childCount; i++)
            {
                if (placeholderParent.GetChild(i).position.x > eventData.position.x)
                {
                    neighborIdx = i;
                    break;
                }
            }
            placeholder.transform.SetSiblingIndex(neighborIdx);
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            // Log.Debug("On drag end!");
            transform.SetParent(parentToReturn);

            canvasGroup.blocksRaycasts = true;

            transform.SetSiblingIndex(placeholder.transform.GetSiblingIndex());
            Destroy(placeholder);

            // List<RaycastResult> raycastResults = new List<RaycastResult>();
            // EventSystem.current.RaycastAll(eventData, raycastResults);
            // foreach (var item in raycastResults)
            // {
            //     Log.Debug(item.gameObject.name);
            //     Log.Debug(item.screenPosition);
            //     Log.Debug(item.sortingLayer);
            // }
        }
    }
}
