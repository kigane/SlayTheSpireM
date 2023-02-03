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
            // 洗牌
            PlayerData.Instance.Shuffle();
            BattleStateManager.instance.ChangeState(BattleStateType.PLAYER);
        }
    }
}
