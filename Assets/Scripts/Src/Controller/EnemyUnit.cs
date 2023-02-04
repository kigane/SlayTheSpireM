using System;
using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace SlayTheSpireM
{
    public class EnemyUnit : BaseUnit
    {
        [SerializeField] CanvasGroup canvasGroup;
        [SerializeField] Image intention;
        [SerializeField] int id;
        private Enemy enemy;
        public Enemy Enemy { get => enemy; }

        private void Awake()
        {
            id = transform.GetSiblingIndex();
            enemy = BattleSession.instance.enemies[id];
            enemy.target = this;

            enemy.hp.Register(val =>
            {
                SetHealthSlider((float)val / enemy.maxHp.Value);
            }).UnRegisterWhenGameObjectDestroyed(gameObject); ;

            enemy.maxHp.Register(val =>
            {
                SetHealthSlider((float)enemy.hp.Value / val);
            }).UnRegisterWhenGameObjectDestroyed(gameObject);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.U))
            {
                AddBuff(new Buff("attack", BuffType.AllBattle, 2));
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
