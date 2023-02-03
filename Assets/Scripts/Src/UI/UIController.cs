using UnityEngine;
using deVoid.UIFramework;
using QFramework;

namespace SlayTheSpireM
{
    public class UIController : BaseMonoController
    {
        [SerializeField] private UISettings defaultUISettings = null;

        protected UIFrame uiFrame;

        private void Awake()
        {
            uiFrame = defaultUISettings.CreateUIInstance();
            this.RegisterEvent<CloseCurrentWindowEvent>(e =>
            {
                uiFrame.CloseCurrentWindow();
            }).UnRegisterWhenGameObjectDestroyed(gameObject);

            this.RegisterEvent<OpenNewScreenEvent>(e =>
            {
                uiFrame.ShowScreen(e.ScreenId);
            }).UnRegisterWhenGameObjectDestroyed(gameObject);
        }

        protected virtual void Start()
        {
            uiFrame.OpenWindow(ScreenIds.GameStartWindow);
            uiFrame.ShowPanel(ScreenIds.BackgroundPanel);
        }
    }
}
