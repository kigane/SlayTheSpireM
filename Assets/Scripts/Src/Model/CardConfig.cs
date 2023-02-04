using QFramework;

namespace SlayTheSpireM
{
    public class CardConfig
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Energy { get; set; }
        public int Rarity { get; set; }
        public int CardType { get; set; }
        public int RoleType { get; set; }
        public string EffectIds { get; set; }
        public string Values { get; set; }
        public string FaceImage { get; set; }
        public string Description { get; set; }
    }
}
