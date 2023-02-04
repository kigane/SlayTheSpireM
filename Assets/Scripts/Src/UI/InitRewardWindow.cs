using UnityEngine;
using UnityEngine.UI;
using deVoid.UIFramework;
using DG.Tweening;
using QFramework;

namespace SlayTheSpireM
{
    public class InitRewardWindow : AQWindowController
    {
        [SerializeField] Button startBattleBtn;

        protected override void AddListeners()
        {
            startBattleBtn.onClick.AddListener(() =>
            {
                // 进入第一场战斗
                this.SendCommand(new OpenNewScreenCommand(GameScreenIds.BattleWindow));
                BattleSession.instance.ChangeState(BattleStateType.Init);
            });
        }
    }
}
