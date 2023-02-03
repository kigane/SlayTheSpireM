using QFramework;

namespace SlayTheSpireM
{
    public class Enemy : BattleUnit
    {
        public int maxHp;
        public int hp;
        public int intention; // 意图

        public void DoAction()
        {
            //TODO 执行意图
        }

        public override void GetDamage(int n)
        {
            throw new System.NotImplementedException();
        }

        public override void GainBlock(int n)
        {
            throw new System.NotImplementedException();
        }

        public override void ApplyBuff(int buffId)
        {
            
            this.SendEvent(new ApplyBuffEvent() { Buff = null });
        }
    }
}
