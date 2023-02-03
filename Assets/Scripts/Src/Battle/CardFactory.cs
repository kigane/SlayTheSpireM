using QFramework;

namespace SlayTheSpireM
{
    public class CardFactory
    {
        public static Card CreateCard(CardConfig cardConfig)
        {
            return new Card(0, "strike", 1, Rarity.COMMON, CardType.ATTACK, RoleType.IRONCLAD, "deal 6 damage");
        }
    }
}
