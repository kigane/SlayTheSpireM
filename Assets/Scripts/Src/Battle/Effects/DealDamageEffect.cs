using QFramework;

namespace SlayTheSpireM
{
    public class DealDamageEffect : Effect
    {
        float multiplier = 1.0f;

        public DealDamageEffect(int val) : base(val)
        {
        }

        public override void Cast(BattleUnit target)
        {
            if (target.CheckIsVulnerable())
                multiplier = 1.5f;
            target.GetDamage((int)(Value * multiplier));
        }
    }
}
