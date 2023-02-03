using QFramework;

namespace SlayTheSpireM
{
    public class DealDamageAction : Action
    {
        readonly int amount;

        public DealDamageAction(int n)
        {
            amount = n;
        }

        public override void Execute()
        {
            target.GetDamage(amount);
        }
    }
}
