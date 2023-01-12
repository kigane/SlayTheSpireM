using UnityEngine;
using UnityEngine.EventSystems;

namespace SlayTheSpireM
{
    public class DropZone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
    {
        public void OnDrop(PointerEventData eventData) // 在OnDragEnd之前触发
        {
            // Log.Debug("OnDrop to " + gameObject.name);
            if (eventData.pointerDrag.TryGetComponent<Draggable>(out var draggable))
            {
                draggable.parentToReturn = transform;
            }
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            // Log.Debug("On Pointer Enter");
            if (eventData.pointerDrag == null)
                return;

            // 将卡牌拖入新区域，就在新区域产生占位符
            if (eventData.pointerDrag.TryGetComponent<Draggable>(out var draggable))
            {
                draggable.placeholderParent = transform;
            }
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            // Log.Debug("On Pointer Exit");
            if (eventData.pointerDrag == null)
                return;

            // 卡牌拖回
            Draggable draggable = eventData.pointerDrag.GetComponent<Draggable>();
            if (draggable != null && draggable.placeholderParent == transform)
            {
                draggable.placeholderParent = draggable.parentToReturn;
            }
        }
    }
}
