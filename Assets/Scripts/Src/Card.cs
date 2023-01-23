namespace SlayTheSpireM
{
    public class Card
    {
        public int id;
        public string name;
        public int energy;
        public Rarity rarity;
        public CardType type;
        public RoleType role;
        public string effect;

        public Card(int i, string n, int e, int r, int t, int c, string eff)
        {
            id = i;
            name = n;
            energy = e;
            rarity = (Rarity)r;
            type = (CardType)t;
            role = (RoleType)c;
            effect = eff;
        }

        public Card(int i, string n, int e, Rarity r, CardType t, RoleType c, string eff)
        {
            id = i;
            name = n;
            energy = e;
            rarity = r;
            type = t;
            role = c;
            effect = eff;
        }

        public Card(Card card)
        {
            id = card.id;
            name = card.name;
            energy = card.energy;
            rarity = card.rarity;
            type = card.type;
            role = card.role;
            effect = card.effect;
        }

        public override string ToString()
        {
            return $"{id} {name}: {energy} {rarity} {type} {role} {effect}";
        }
    }
}
