using UnityEngine;
using UnityEngine.UI;

namespace SlayTheSpireM
{
    public class InitRewardView : View
    {
        [SerializeField] Button startBattleBtn;
        public override void Init()
        {
            startBattleBtn.onClick.AddListener(() =>
            {
                ViewManager.Show<BattleView>(false);
                BattleStateManager.instance.ChangeState(BattleStateType.INIT);
            });
        }
    }
}
