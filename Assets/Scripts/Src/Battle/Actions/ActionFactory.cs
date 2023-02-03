using QFramework;
using System;

namespace SlayTheSpireM
{
    public class ActionFactory
    {
        public static Action CreateAction(int id, int val)
        {
            return id switch
            {
                0 => new DealDamageAction(val),
                1 => new GainBlockAction(val),
                2 => new DrawCardsAction(val),
                3 => new ApplyBuffAction(val),
                _ => throw new NotSupportedException("不支持的行动"),
            };
        }
    }
}
