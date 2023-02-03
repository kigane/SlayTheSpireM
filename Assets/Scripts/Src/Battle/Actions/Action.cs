using QFramework;

namespace SlayTheSpireM
{
    public abstract class Action : ICommand
    {
        protected BattleUnit target;

        public Action() { }

        public void SetTarget(BattleUnit unit)
        {
            target = unit;
        }

        private IArchitecture mArchitecture;

        IArchitecture IBelongToArchitecture.GetArchitecture()
        {
            return mArchitecture;
        }

        void ICanSetArchitecture.SetArchitecture(IArchitecture architecture)
        {
            mArchitecture = architecture;
        }

        public abstract void Execute();
    }
}
