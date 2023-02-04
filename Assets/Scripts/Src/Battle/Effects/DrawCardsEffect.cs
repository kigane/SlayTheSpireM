using QFramework;

namespace SlayTheSpireM
{
    public class DrawCardsEffect : Effect
    {
        readonly int amount;

        public DrawCardsEffect(int n)
        {
            amount = n;
        }

        public override void Cast(BattleUnit target)
        {
            //TODO
            this.SendEvent(DrawCardsEvent.SetAmount(amount));
        }
    }
}
