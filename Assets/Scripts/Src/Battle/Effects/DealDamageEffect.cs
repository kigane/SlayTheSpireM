using QFramework;

namespace SlayTheSpireM
{
    public class DealDamageEffect : Effect
    {
        readonly int amount;
        float multiplier = 1.0f;

        public DealDamageEffect(int n)
        {
            amount = n;
        }

        public override void Cast(BattleUnit target)
        {
            if (target.CheckIsVulnerable())
                multiplier = 1.5f;
            target.GetDamage((int)(amount * multiplier));
        }
    }
}
