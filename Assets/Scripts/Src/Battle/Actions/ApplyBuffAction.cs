using QFramework;

namespace SlayTheSpireM
{
    public class ApplyBuffAction : Action
    {
        readonly int buffId;

        public ApplyBuffAction(int id)
        {
            buffId = id;
        }

        public override void Execute()
        {
            //TODO
            target.ApplyBuff(buffId);
        }
    }
}
