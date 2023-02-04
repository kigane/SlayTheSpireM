using QFramework;

namespace SlayTheSpireM
{
    public class BattleInit : BattleState
    {
        public override void Enter()
        {
            Log.Info("战斗开始!");
            //TODO 播放BGM
            //TODO UI动画
            // 战斗准备
            BattleSession.instance.SessionStart();
            BattleSession.instance.ChangeState(BattleStateType.PlayerTurn);
        }
    }
}
