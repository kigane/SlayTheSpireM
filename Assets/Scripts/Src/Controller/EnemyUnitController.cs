using System;
using UnityEngine;
using UnityEngine.UI;
using QFramework;
using DG.Tweening;
using TMPro;

namespace SlayTheSpireM
{
    public class EnemyUnitController : BaseUnitController
    {
        [SerializeField] Image intention;
        [SerializeField] Image enemyImage;
        [SerializeField] GameObject blockGO;
        [SerializeField] TextMeshProUGUI blockNumberText;
        [SerializeField] int id;
        CanvasGroup canvasGroup;
        private Enemy enemy;
        public Enemy Enemy { get => enemy; }

        private void Awake()
        {
            canvasGroup = GetComponent<CanvasGroup>();
            id = transform.GetSiblingIndex();
            enemy = BattleSession.instance.enemies[id];
            enemy.view = this;

            enemy.hp.Register(val =>
            {
                if (val <= 0)
                {
                    BattleSession.instance.enemies[id] = null;
                    canvasGroup.DOFade(0, 0.3f).OnComplete(() => { enemyImage.raycastTarget = false; });
                }
                SetHealthSlider((float)val / enemy.maxHp.Value);
            }).UnRegisterWhenGameObjectDestroyed(gameObject); ;

            enemy.maxHp.Register(val =>
            {
                SetHealthSlider((float)enemy.hp.Value / val);
            }).UnRegisterWhenGameObjectDestroyed(gameObject);

            enemy.block.Register(val =>
            {
                if (val > 0)
                {
                    blockGO.SetActive(true);
                    blockNumberText.text = val.ToString();
                }
                else
                {
                    blockGO.SetActive(false);
                }
            }).UnRegisterWhenGameObjectDestroyed(gameObject);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.U))
            {
                // AddBuff(new Buff("attack", BuffType.AllBattle, 2));
                new GainBlockEffect(5).Cast(enemy);
            }

            if (Input.GetKeyDown(KeyCode.I))
            {
                ShowIntention();
            }

            if (Input.GetKeyDown(KeyCode.O))
            {
                HideIntention();
            }
        }

        public void ShowIntention()
        {
            intention.gameObject.SetActive(true);
        }

        public void HideIntention()
        {
            intention.gameObject.SetActive(false);
        }
    }
}
