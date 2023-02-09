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
        [SerializeField] GameObject intention;
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

                    canvasGroup.DOFade(0, 0.3f).OnComplete(() =>
                    {
                        enemyImage.raycastTarget = false;
                        if (BattleSession.instance.AreEnemiesAllNull())
                        {
                            // 战斗胜利
                            BattleSession.instance.ChangeState(BattleStateType.Win);
                        }
                    });
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

            this.RegisterEvent<PlayerTurnStartEvent>(e =>
            {
                intention.GetComponent<IntentDisplayer>().SetData(enemy.CurrIntent);
                intention.SetActive(true);
                UpdateBuffValue();
            }).UnRegisterWhenGameObjectDestroyed(gameObject);

            this.RegisterEvent<PlayerTurnEndEvent>(e =>
            {
                intention.SetActive(false);
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
            intention.SetActive(true);
        }

        public void HideIntention()
        {
            intention.SetActive(false);
        }

        public void UpdateBuffValue()
        {
            // Log.Debug(nameof(UpdateBuffValue));
            foreach (var buff in Buffs)
            {
                buff.Update();
                if (buff.Value == 0)
                {
                    Destroy(buff.instance);
                }
                buff.Text.text = buff.Value.ToString();
                enemy.RemoveBuff(buff);
            }
        }
    }
}
