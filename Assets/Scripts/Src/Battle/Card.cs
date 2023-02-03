namespace SlayTheSpireM
{
    public class Card
    {
        public int id;

        // 需要展示的信息
        public string name;
        public int energy;
        public Rarity rarity;
        public CardType type;
        public RoleType role;
        public string description;

        public Action action;

        public Card(CardConfig cardConfig)
        {
            id = cardConfig.Id;
            name = cardConfig.Name;
            energy = cardConfig.Energy;
            rarity = (Rarity)cardConfig.Rarity;
            type = (CardType)cardConfig.CardType;
            role = (RoleType)cardConfig.RoleType;
        }

        public Card(int i, string n, int e, int r, int t, int c, string eff)
        {
            id = i;
            name = n;
            energy = e;
            rarity = (Rarity)r;
            type = (CardType)t;
            role = (RoleType)c;
            description = eff;
        }

        public Card(int i, string n, int e, Rarity r, CardType t, RoleType c, string eff)
        {
            id = i;
            name = n;
            energy = e;
            rarity = r;
            type = t;
            role = c;
            description = eff;
        }

        public Card(Card card)
        {
            id = card.id;
            name = card.name;
            energy = card.energy;
            rarity = card.rarity;
            type = card.type;
            role = card.role;
            description = card.description;
        }

        public override string ToString()
        {
            return $"{id} {name}: {energy} {rarity} {type} {role} {description}";
        }
    }
}
