using System.Collections.Generic;
using QFramework;

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
        public BaseUnitController target;

        public virtual void GetDamage(int n)
        {
            hp.Value -= n;
            FloatingTextManager.Instance.ShowFloatingText($"-{n}", target.transform);
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
            if (target != null)
                target.AddBuff(buff);
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
