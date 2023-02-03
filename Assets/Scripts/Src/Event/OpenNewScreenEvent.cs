using QFramework;

namespace SlayTheSpireM
{
    public class OpenNewScreenEvent
    {
        public static OpenNewScreenEvent instance = new();

        public string screenId;
        public string ScreenId => screenId;

        public static OpenNewScreenEvent SetAmount(string id)
        {
            instance.screenId = id;
            return instance;
        }
    }
}
