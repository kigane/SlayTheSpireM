using QFramework;

namespace SlayTheSpireM
{
    public class DealDamageEffect : Effect
    {
        readonly int amount;

        public DealDamageEffect(int n)
        {
            amount = n;
        }

        public override void Cast(BattleUnit target)
        {
            target.GetDamage(amount);
        }
    }
}
