using System.Collections.Generic;
using QFramework;

namespace SlayTheSpireM
{
    public class CompositeEffect : Effect
    {
        readonly List<Effect> mEffects = new();

        // params 指定数目可变的参数，参数声明需要写成数组的形式
        // 使用时，可以传入逗号分隔的参数列表(参数类型必须一致)
        // 可以传入指定类型参数的数组
        // 参数可以为空
        public CompositeEffect(params Effect[] effects)
        {
            for (int i = 0; i < effects.Length; i++)
            {
                mEffects.Add(effects[i]);
            }
        }

        public override void Cast(BattleUnit target)
        {
            for (int i = 0; i < mEffects.Count; i++)
            {
                mEffects[i].Cast(target);
            }
        }

        public override string ToString()
        {
            string ret = "";
            for (int i = 0; i < mEffects.Count; i++)
            {
                ret += mEffects[i].ToString() + "\n";
            }
            return base.ToString();
        }
    }
}
