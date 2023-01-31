using UnityEngine;
using UnityEngine.UI;
using deVoid.UIFramework;
using DG.Tweening;

namespace SlayTheSpireM
{
    public class GameUIController : UIController
    {
        protected override void Start()
        {
            uiFrame.OpenWindow(GameScreenIds.InitRewardWindow);
            uiFrame.ShowPanel(GameScreenIds.GameBackgroundPanel);
            uiFrame.ShowPanel(GameScreenIds.StatusPanel);
        }
    }
}