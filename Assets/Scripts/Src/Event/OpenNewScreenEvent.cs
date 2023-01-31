using QFramework;

namespace SlayTheSpireM
{
    public class OpenNewScreenEvent
    {
        public string screenId;

        public OpenNewScreenEvent() { }

        public OpenNewScreenEvent(string id)
        {
            screenId = id;
        }
    }
}
