using QFramework;

namespace SlayTheSpireM
{
    public class OpenNewScreenCommand : AbstractCommand
    {
        public string screenId;

        public OpenNewScreenCommand(string id)
        {
            screenId = id;
        }

        protected override void OnExecute()
        {
            this.SendEvent(new OpenNewScreenEvent(screenId));
        }
    }
}