using UnityEngine;
using UnityEngine.EventSystems;

namespace SlayTheSpireM
{
    public class DropZone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
    {
        public void OnDrop(PointerEventData eventData) // 在OnDragEnd之前触发
        {
            // Log.Debug("OnDrop to " + gameObject.name);
            // if (eventData.pointerDrag.TryGetComponent<Draggable>(out var draggable))
            // {
            //     draggable.parentToReturn = transform;
            // }
            // TODO 获取脚本，执行脚本的某个方法
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            // Log.Debug("On Pointer Enter");
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            // Log.Debug("On Pointer Exit");
        }
    }
}
