using QFramework;
using System;

namespace SlayTheSpireM
{
    public class ApplyBuffEffect : Effect
    {
        readonly Buff buff;

        public ApplyBuffEffect(int id)
        {
            buff = id switch
            {
                0 => new Buff("weak", BuffType.LastTurns, 2),
                1 => new Buff("vulnerable", BuffType.LastTurns, 2),
                _ => throw new NotImplementedException("未实现的Buff")
            };
        }

        public override void Cast(BattleUnit target)
        {
            //TODO
            Log.Debug("ApplyBuffEffect Target", target);
            Log.Debug("ApplyBuffEffect Buff", buff);
            target.ApplyBuff(buff);
        }
    }
}
