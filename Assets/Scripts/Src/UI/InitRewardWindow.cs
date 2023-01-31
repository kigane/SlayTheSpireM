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
                this.SendCommand(new OpenNewScreenCommand(GameScreenIds.BattleWindow));
                BattleStateManager.instance.ChangeState(BattleStateType.INIT);
            });
        }
    }
}
