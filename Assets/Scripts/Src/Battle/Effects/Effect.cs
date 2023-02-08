using QFramework;

namespace SlayTheSpireM
{
    public interface IEffect
    {
        void Cast(BattleUnit target);
    }

    public abstract class Effect : IEffect, ICanSendEvent
    {
        public TargetType TargetType { get; set; }
        public string Description { get; set; }
        public int Value;

        public Effect() { }

        public Effect(int val)
        {
            Value = val;
        }

        public abstract void Cast(BattleUnit target);

        public override string ToString()
        {
            return Description.Replace("#", Value.ToString());
        }

        public IArchitecture GetArchitecture()
        {
            return SlayTheSpireGame.Interface;
        }
    }
}
