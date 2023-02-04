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

        public abstract void Cast(BattleUnit target);

        public IArchitecture GetArchitecture()
        {
            return SlayTheSpireGame.Interface;
        }
    }
}
