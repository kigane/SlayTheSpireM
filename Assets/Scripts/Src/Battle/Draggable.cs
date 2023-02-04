using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening;

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

        // 点击时确定pointerDrag，只要不放开pointerDrag就不会变。
        public void OnBeginDrag(PointerEventData eventData)
        {
            startPoint = eventData.position;
            eventData.pointerDrag.transform.DOScale(new Vector3(1.5f, 1.5f, 1f), 0.5f);
        }

        public void OnDrag(PointerEventData eventData)
        {
            // 指示箭头
            var line = lineUi.GetComponent<Line>();
            lineUi.SetActive(true);
            line.SetStartPoint(startPoint, eventData.pressEventCamera);
            line.SetEndPoint(eventData.position, eventData.pressEventCamera);
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            // 表现
            lineUi.SetActive(false);
            eventData.pointerDrag.transform.DOScale(new Vector3(1f, 1f, 1f), 0.5f);

            // 获取打出的卡牌在手牌中的序号
            var cardIdxInHand = transform.GetSiblingIndex();
            var card = BattleSession.instance.deck.GetCardById(BattleSession.instance.player.handCards[cardIdxInHand]);
            Log.Debug("===================");
            Log.Debug("打出牌在手牌中的序号", cardIdxInHand.ToString());
            Log.Debug("Card Target Type", card.effect.TargetType);
            Log.Debug("===================");

            // 确定卡牌作用对象
            List<RaycastResult> raycastResults = new();
            EventSystem.current.RaycastAll(eventData, raycastResults);
            foreach (var item in raycastResults)
            {
                if (card.effect.TargetType == TargetType.Enemy) // 作用于一个敌人的卡
                {
                    if (item.gameObject.name == "Enemy Image") // 移动到目标上
                    {
                        gameObject.SetActive(false);
                        var target = item.gameObject.GetComponentInParent<EnemyUnit>();
                        Log.Debug("Enemy Image", target.Enemy);
                        BattleSession.instance.player.PlayACard(cardIdxInHand, target.Enemy);
                    }
                    // 没有移动到目标上，无事发生
                    break;
                }
                else if (item.gameObject.name == "Battle Field") // 非作用于一个敌人的卡，进入场地
                {
                    Log.Debug("Battle Field");
                    gameObject.SetActive(false);
                    if (card.effect.TargetType == TargetType.AllEnemy)
                    {
                        //TODO
                    }
                    else
                    { // 对玩家起作用的牌
                        // Log.Debug("Battle Field", item.screenPosition);
                        BattleSession.instance.player.PlayACard(cardIdxInHand, null);
                    }
                    break;
                }
            }
        }
    }
}
