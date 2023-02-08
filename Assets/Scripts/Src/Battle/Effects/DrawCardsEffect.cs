using QFramework;

namespace SlayTheSpireM
{
    public class DrawCardsEffect : Effect
    {
        public DrawCardsEffect(int val) : base(val)
        {
        }

        public override void Cast(BattleUnit target)
        {
            //TODO
            this.SendEvent(DrawCardsEvent.SetAmount(Value));
        }
    }
}
