using QFramework;

namespace SlayTheSpireM
{
    public class DrawCardsEvent
    {
        public static DrawCardsEvent instance = new();

        int amount;
        public int Amount => amount;

        public static DrawCardsEvent SetAmount(int n)
        {
            instance.amount = n;
            return instance;
        }
    }
}
