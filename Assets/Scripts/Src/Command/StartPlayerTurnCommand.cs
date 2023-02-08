using QFramework;

namespace SlayTheSpireM
{
    public class StartPlayerTurnCommand : AbstractCommand
    {
        protected override void OnExecute()
        {
            this.SendEvent<PlayerTurnStartEvent>();
        }
    }
}