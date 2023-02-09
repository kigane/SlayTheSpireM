using QFramework;

namespace SlayTheSpireM
{
    public class BattleWin : BattleState
    {
        public override void Enter()
        {
            Log.Debug("战斗胜利!");
            this.SendCommand(new OpenNewScreenCommand(GameScreenIds.BattleWinWindow));
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
        }
    }
}
