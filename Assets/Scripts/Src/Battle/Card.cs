namespace SlayTheSpireM
{
    public class Card
    {
        public int id;

        // 需要展示的信息
        public string name;
        public string spritePath;
        public int energy;
        public Rarity rarity;
        public CardType type;
        public RoleType role;
        public string description;

        public Effect effect;

        public Card(CardConfig cardConfig)
        {
            id = cardConfig.Id;
            name = cardConfig.Name;
            spritePath = cardConfig.SpritePath;
            energy = cardConfig.Energy;
            rarity = (Rarity)cardConfig.Rarity;
            type = (CardType)cardConfig.CardType;
            role = (RoleType)cardConfig.RoleType;
            effect = EffectFactory.CreateEffect(cardConfig.EffectIds, cardConfig.Values);
            description = effect.ToString();
        }

        public void Play(BattleUnit target)
        {
            effect.Cast(target);
        }

        public override string ToString()
        {
            return $"{id} {name} {spritePath}: {energy} {rarity} {type} {role} {description}";
        }
    }
}
