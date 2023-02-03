using QFramework;
using UnityEngine;
using UnityEngine.UI;

namespace SlayTheSpireM
{
    public class Line : MonoBehaviour
    {
        RectTransform rectTransform;

        private void Awake()
        {// 初始为未激活状态的GO的Awake方法不会立即被调用，当GO激活时才第一次调用。
            rectTransform = GetComponent<RectTransform>();
            // Log.Debug("Rect", rectTransform);
        }

        /// <summary>
        /// 设置起点
        /// </summary>
        /// <param name="pos">屏幕坐标</param>
        /// <param name="camera">对应的相机</param>
        public void SetStartPoint(Vector2 pos, Camera camera)
        {
            // Log.Debug("Set Rect", rectTransform);
            RectTransformUtility.ScreenPointToWorldPointInRectangle(rectTransform, pos, camera, out var startPos);
            transform.GetChild(0).GetComponent<RectTransform>().position = startPos;
        }

        /// <summary>
        /// 设置曲线终点，并设置曲线各部分的位置和朝向
        /// </summary>
        /// <param name="pos">终点的屏幕坐标</param>
        /// <param name="camera">对应的相机</param>
        public void SetEndPoint(Vector2 pos, Camera camera)
        {
            RectTransformUtility.ScreenPointToWorldPointInRectangle(rectTransform, pos, camera, out var endPoint);
            transform.GetChild(transform.childCount - 1).GetComponent<RectTransform>().position = endPoint;

            // 使用世界坐标进行后续计算
            var startPoint = transform.GetChild(0).GetComponent<RectTransform>().position;
            var midPoint = Vector2.zero;
            midPoint.x = startPoint.x;
            midPoint.y = (startPoint.y + endPoint.y) * 0.5f;
            transform.GetChild(transform.childCount - 1).eulerAngles = CalcRotationOfSingleArrow(startPoint, endPoint);

            for (int i = 0; i < transform.childCount - 1; i++)
            {
                // 确定在曲线上的位置
                transform.GetChild(i).GetComponent<RectTransform>().position = GetBezier(startPoint, midPoint, endPoint, i / (float)transform.childCount);

                // 计算偏转角度
                transform.GetChild(i).eulerAngles = CalcRotationOfSingleArrow(transform.GetChild(i).GetComponent<RectTransform>().position, transform.GetChild(i + 1).GetComponent<RectTransform>().position);
            }
        }

        private Vector3 CalcRotationOfSingleArrow(Vector3 startPoint, Vector3 endPoint)
        {
            Vector3 dir = (endPoint - startPoint).normalized;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            return new Vector3(0, 0, angle - 90);
        }



        public Vector3 GetBezier(Vector3 start, Vector3 mid, Vector3 end, float t)
        {
            return (1f - t) * (1f - t) * start + 2 * t * (1f - t) * mid + t * t * end;
        }
    }
}
