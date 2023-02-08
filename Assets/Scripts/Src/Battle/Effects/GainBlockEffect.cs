using QFramework;

namespace SlayTheSpireM
{
    public class GainBlockEffect : Effect
    {
        public GainBlockEffect(int val) : base(val)
        {
        }

        public override void Cast(BattleUnit target)
        {
            target.GainBlock(Value);
        }
    }
}
