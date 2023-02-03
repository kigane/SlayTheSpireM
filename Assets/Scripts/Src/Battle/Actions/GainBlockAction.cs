using QFramework;

namespace SlayTheSpireM
{
    public class GainBlockAction : Action
    {
        readonly int amount;

        public GainBlockAction(int n)
        {
            amount = n;
        }

        public override void Execute()
        {
            target.GainBlock(amount);
        }
    }
}
