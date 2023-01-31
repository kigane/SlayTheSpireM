using QFramework;

namespace SlayTheSpireM
{
    public class CloseCurrentScreenCommand : AbstractCommand
    {
        protected override void OnExecute()
        {
            this.SendEvent<CloseCurrentWindowEvent>();
        }
    }
}