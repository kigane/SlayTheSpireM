using System;
using UnityEngine;
using UnityEngine.UI;

namespace SlayTheSpireM
{
    public class EnemyUnit : BaseUnit
    {
        [SerializeField] Image intention;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.U))
            {
                AddBuff(new Buff("attack", BuffType.NUMBER, 0, 2));
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
