using QFramework;
using System;

namespace SlayTheSpireM
{
    public class EffectFactory
    {
        public static Effect CreateEffect(string id, string val)
        {
            string[] ids = id.Split(',');
            string[] vals = val.Split(',');

            if (ids.Length != vals.Length)
            {
                Log.Error("效果id和数值数组长度不一致!");
                return null;
            }

            Effect ret;
            if (ids.Length == 1)
            {
                ret = BuildEffect(id, val);
            }
            else
            {
                Effect[] effect = new Effect[ids.Length];
                for (int i = 0; i < ids.Length; i++)
                {
                    effect[i] = BuildEffect(ids[i], vals[i]);
                }
                ret = new CompositeEffect(effect) { TargetType = TargetType.Enemy };
            }
            return ret;
        }


        /// <summary>
        /// 根据配置构造卡牌效果
        /// </summary>
        /// <param name="id"></param>
        /// <param name="val"></param>
        /// <returns></returns>
        public static Effect BuildEffect(string id, string val)
        {
            int value = int.Parse(val);
            return int.Parse(id) switch
            {
                1 => new DealDamageEffect(value) { TargetType = TargetType.Enemy, Description = "Deal # damage." },
                2 => new GainBlockEffect(value) { TargetType = TargetType.Self, Description = "Gain # block." },
                3 => new DrawCardsEffect(value) { TargetType = TargetType.None, Description = "Draw # cards." },
                4 => new ApplyBuffEffect(value) { TargetType = TargetType.Enemy, Description = "Apply #" },
                _ => throw new NotSupportedException("不支持的效果"),
            };
        }
    }
}
