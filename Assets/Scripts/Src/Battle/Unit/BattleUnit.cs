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

        //FIXME 相互依赖
        public BaseUnit target;

        public abstract void GetDamage(int n);
        public abstract void GainBlock(int n);

        //添加或更新一个图标，修改数据
        public void ApplyBuff(Buff buff)
        {
            Log.Debug("BattleUnit.ApplyBuff");
            buffs.Add(buff);
            if (target != null)
                target.AddBuff(buff);
        }

        public void RemoveBuff(Buff buff)
        {
            buffs.Remove(buff);
        }

        public IArchitecture GetArchitecture()
        {
            return SlayTheSpireGame.Interface;
        }
    }
}
