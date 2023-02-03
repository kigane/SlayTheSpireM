using System.Collections.Generic;
using QFramework;

namespace SlayTheSpireM
{
    public abstract class BattleUnit : ICanSendEvent
    {
        // 战斗时状态
        public int block;
        public int strength;
        public int dexterity;
        public List<BuffIcon> buffs;

        public abstract void GetDamage(int n);

        public abstract void GainBlock(int n);

        //添加或更新一个图标，修改数据
        public abstract void ApplyBuff(int buffId);

        public IArchitecture GetArchitecture()
        {
            return SlayTheSpireGame.Interface;
        }
    }
}
