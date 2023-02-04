using QFramework;

namespace SlayTheSpireM
{
    public class GainBlockEffect : Effect
    {
        readonly int amount;

        public GainBlockEffect(int n)
        {
            amount = n;
        }

        public override void Cast(BattleUnit target)
        {
            target.GainBlock(amount);
        }
    }
}
