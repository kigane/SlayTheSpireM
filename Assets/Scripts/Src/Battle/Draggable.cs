using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening;
using System.Collections;

namespace SlayTheSpireM
{
    public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        public GameObject lineUi;
        Vector2 startPoint;
        int cardIdxInHand;
        Card card;
        TargetType targetType;

        // 点击时确定pointerDrag，只要不放开pointerDrag就不会变。
        public void OnBeginDrag(PointerEventData eventData)
        {
            // 获取打出的卡牌在手牌中的序号
            cardIdxInHand = transform.GetSiblingIndex();
            card = BattleSession.instance.deck.GetCardById(BattleSession.instance.player.handCards[cardIdxInHand]);
            targetType = card.effect.TargetType;

            startPoint = eventData.position;
            // Log.Debug("Begin Scale", eventData.pointerDrag.name);
            eventData.pointerDrag.transform.DOScale(new Vector3(1.5f, 1.5f, 1f), 0.3f);
        }

        public void OnDrag(PointerEventData eventData)
        {
            // 指示箭头
            if (targetType == TargetType.Enemy)
            {
                var line = lineUi.GetComponent<Line>();
                lineUi.SetActive(true);
                line.SetStartPoint(startPoint, eventData.pressEventCamera);
                line.SetEndPoint(eventData.position, eventData.pressEventCamera);
            }
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            // 表现
            lineUi.SetActive(false);

            // 直接设置会因为出牌速度快，DoScale还没跑完导致，设置后被DoScale又改回去.
            // Log.Debug($"{eventData.pointerDrag.name} Local Scale", eventData.pointerDrag.transform.localScale);
            // eventData.pointerDrag.transform.localScale = new Vector3(1f, 1f, 1f);
            // Log.Debug($"{eventData.pointerDrag.name} Local Scale", eventData.pointerDrag.transform.localScale);
            eventData.pointerDrag.transform.DOScale(new Vector3(1f, 1f, 1f), 0.3f);


            // Log.Debug("===================");
            // Log.Debug("打出牌在手牌中的序号", cardIdxInHand.ToString());
            // Log.Debug("Card Target Type", targetType);
            // Log.Debug("===================");

            // 确定卡牌作用对象
            List<RaycastResult> raycastResults = new();
            EventSystem.current.RaycastAll(eventData, raycastResults);
            foreach (var item in raycastResults)
            {
                if (targetType == TargetType.Enemy) // 作用于一个敌人的卡
                {
                    if (item.gameObject.name == "Enemy Image") // 移动到目标上
                    {
                        var target = item.gameObject.GetComponentInParent<EnemyUnitController>();
                        // Log.Debug("Enemy Image", target.Enemy);
                        // 打出手牌后触发HandCardsUpdateEvent。会重新给卡牌编号并自动减少显示的卡牌。
                        var success = BattleSession.instance.player.PlayACard(cardIdxInHand, target.Enemy);
                        // gameObject.SetActive(!success);
                    }
                    // 没有移动到目标上，无事发生
                    break;
                }
                else if (item.gameObject.name == "Battle Field") // 非作用于一个敌人的卡，进入场地
                {
                    var success = false;

                    // 在打出前复制，否则打出后牌的内容会变。(因为手牌更新方式)
                    var effectGOTransform = Instantiate(transform.gameObject, Camera.main.ScreenToWorldPoint(eventData.position), Quaternion.identity, transform.parent.parent).transform;

                    // Log.Debug("Battle Field");
                    if (targetType == TargetType.AllEnemy)
                    {
                        //TODO
                    }
                    else
                    { // 对玩家起作用的牌
                        // Log.Debug("Battle Field", item.screenPosition);
                        success = BattleSession.instance.player.PlayACard(cardIdxInHand, null);
                        // gameObject.SetActive(!success);
                    }

                    // 卡牌移动到中间展示动画 
                    if (success)
                        effectGOTransform.DOMove(Camera.main.ScreenToWorldPoint(new Vector3(810, 540, 0)), 0.7f).OnComplete(() => Destroy(effectGOTransform.gameObject));
                    // eventData.pointerDrag.transform.DOMove(Camera.main.ScreenToWorldPoint(new Vector3(810, 540, 0)), 0.7f).OnComplete(() => eventData.pointerDrag.transform.DOScale(new Vector3(1f, 1f, 1f), 0.5f));

                    break;
                }
            }
        }

        private IEnumerator ShowCardInCenter(Transform transform)
        {
            transform.DOMove(Camera.main.ScreenToWorldPoint(new Vector3(810, 540, 0)), 0.7f).OnComplete(() => transform.localScale = new Vector3(1f, 1f, 1f));
            transform.SetParent(transform.parent);
            yield return null;
        }
    }
}
