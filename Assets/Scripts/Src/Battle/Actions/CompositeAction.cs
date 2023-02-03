using System.Collections.Generic;
using QFramework;

namespace SlayTheSpireM
{
    public class CompositeAction : Action
    {
        readonly List<Action> mActions;

        // params 指定数目可变的参数，参数声明需要写成数组的形式
        // 使用时，可以传入逗号分隔的参数列表(参数类型必须一致)
        // 可以传入指定类型参数的数组
        // 参数可以为空
        public CompositeAction(params Action[] actions)
        {
            for (int i = 0; i < actions.Length; i++)
            {
                mActions.Add(actions[i]);
            }
        }

        //TODO 目标设定

        public override void Execute()
        {
            for (int i = 0; i < mActions.Count; i++)
            {
                mActions[i].Execute();
            }
        }
    }
}
