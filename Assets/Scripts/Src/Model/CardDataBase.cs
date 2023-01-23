using QFramework;
using System.Collections.Generic;

namespace SlayTheSpireM
{
    public class CardDataBase : AbstractModel
    {
        public readonly List<Card> cards = new();

        protected override void OnInit()
        {
            cards.Add(new Card(0, "strike", 1, Rarity.COMMON, CardType.ATTACK, RoleType.IRONCLAD, "deal 6 damage"));
            cards.Add(new Card(1, "defense", 1, Rarity.COMMON, CardType.SKILL, RoleType.IRONCLAD, "add 5 block"));
            cards.Add(new Card(2, "strong strike", 2, Rarity.COMMON, CardType.ATTACK, RoleType.IRONCLAD, "deal 8 damage and apply 2 vulnerable"));

            cards.Add(new Card(3, "strike", 1, Rarity.COMMON, CardType.ATTACK, RoleType.SILENT, "deal 6 damage"));
            cards.Add(new Card(4, "defense", 1, Rarity.COMMON, CardType.SKILL, RoleType.SILENT, "add 5 block"));

            cards.Add(new Card(5, "strike", 1, Rarity.COMMON, CardType.ATTACK, RoleType.DEFECT, "deal 6 damage"));
            cards.Add(new Card(6, "defense", 1, Rarity.COMMON, CardType.SKILL, RoleType.DEFECT, "add 5 block"));

            cards.Add(new Card(7, "strike", 1, Rarity.COMMON, CardType.ATTACK, RoleType.WATCHER, "deal 6 damage"));
            cards.Add(new Card(8, "defense", 1, Rarity.COMMON, CardType.SKILL, RoleType.WATCHER, "add 5 block"));
        }
    }
}
