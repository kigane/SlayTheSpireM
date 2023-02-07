using System.Collections.Generic;
using QFramework;
using UnityEngine;

namespace SlayTheSpireM
{
    public abstract class BattleUnit : ICanSendEvent
    {
        // 战斗时状态
        public int strength;
        public int dexterity;
        public List<Buff> buffs = new();
        public BindableProperty<int> hp = new(20);
        public BindableProperty<int> maxHp = new(20);
        public BindableProperty<int> block = new(0);

        //FIXME 相互依赖
        public BaseUnitController view;

        public virtual void GetDamage(int damage)
        {
            var color = Color.red;
            if (block.Value > 0)
            {
                if (damage < block.Value)
                {
                    block.Value -= damage;
                    damage = 0;
                    color = Color.blue;
                }
                else
                {
                    damage -= block.Value;
                    block.Value = 0;
                }
            }
            hp.Value -= damage;
            FloatingTextManager.Instance.ShowFloatingText($"-{damage}", view.transform, color);
        }

        public virtual void GainBlock(int n)
        {
            block.Value += n;
        }

        //添加或更新一个图标，修改数据
        public void ApplyBuff(Buff buff)
        {
            Log.Debug("BattleUnit.ApplyBuff", buff);
            buffs.Add(buff);
            if (view != null)
                view.AddBuff(buff);
        }

        public void RemoveBuff(Buff buff)
        {
            buffs.Remove(buff);
        }

        public bool CheckIsVulnerable()
        {
            foreach (var buff in buffs)
            {
                if (buff.Name == "vulnerable")
                {
                    return true;
                }
            }
            return false;
        }

        public IArchitecture GetArchitecture()
        {
            return SlayTheSpireGame.Interface;
        }
    }
}
