using QFramework;

namespace SlayTheSpireM
{
    public class DrawCardsAction : Action
    {
        readonly int amount;

        public DrawCardsAction(int n)
        {
            amount = n;
        }

        public override void Execute()
        {
            //TODO
            this.SendEvent(DrawCardsEvent.SetAmount(amount));
        }
    }
}
