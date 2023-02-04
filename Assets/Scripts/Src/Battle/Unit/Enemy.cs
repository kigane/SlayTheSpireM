using QFramework;

namespace SlayTheSpireM
{
    public class Enemy : BattleUnit
    {
        public BindableProperty<int> maxHp = new(20);
        public BindableProperty<int> hp = new(20);
        public BindableProperty<int> block = new(0);
        public int intention; // 意图

        public void DoAction()
        {
            //TODO 执行意图
        }

        public override void GetDamage(int n)
        {
            hp.Value -= n;
        }

        public override void GainBlock(int n)
        {
            block.Value += n;
        }
    }
}
