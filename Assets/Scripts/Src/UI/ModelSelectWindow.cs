using UnityEngine;
using UnityEngine.UI;
using deVoid.UIFramework;
using QFramework;
using DG.Tweening;

namespace SlayTheSpireM
{
    public class ModelSelectWindow : AQWindowController
    {
        [SerializeField] private Button returnBtn;
        [SerializeField] private Button normalModeBtn;

        protected override void AddListeners()
        {
            returnBtn.onClick.AddListener(() => this.SendCommand<CloseCurrentScreenCommand>());
            normalModeBtn.onClick.AddListener(() => this.SendCommand(new OpenNewScreenCommand(ScreenIds.CharacterSelectWindow)));
        }
    }
}