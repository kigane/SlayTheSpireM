using QFramework;

namespace SlayTheSpireM
{
    public class CardFactory
    {
        public static Card CreateCard(CardConfig cardConfig)
        {
            return new Card(cardConfig);
        }
    }
}
