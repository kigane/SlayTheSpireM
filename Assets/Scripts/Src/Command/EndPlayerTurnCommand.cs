using QFramework;

namespace SlayTheSpireM
{
    public class EndPlayerTurnCommand : AbstractCommand
    {
        protected override void OnExecute()
        {
            this.SendEvent<PlayerTurnEndEvent>();
        }
    }
}