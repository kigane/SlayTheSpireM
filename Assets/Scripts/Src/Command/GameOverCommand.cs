using QFramework;

namespace SlayTheSpireM
{
    public class GameOverCommand : AbstractCommand
    {
        protected override void OnExecute()
        {
            this.SendCommand(new OpenNewScreenCommand(GameScreenIds.GameOverWindow));
        }
    }
}