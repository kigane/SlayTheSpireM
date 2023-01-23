using QFramework;

namespace SlayTheSpireM
{
    public class UpdateHandCardsViewCommand : AbstractCommand
    {
        protected override void OnExecute()
        {
            this.SendEvent<HandCardsUpdateEvent>();
        }
    }
}