using UnityEngine;
using UnityEngine.UI;

namespace SlayTheSpireM
{
    public class StartView : View
    {
        [SerializeField] private Button startBtn;
        [SerializeField] private Button exitBtn;

        public override void Init()
        {
            startBtn.onClick.AddListener(() => { ViewManager.Show<ModeSelectView>(true); });
            exitBtn.onClick.AddListener(OnExit);
        }

        private void OnExit()
        {
            Log.Debug("quit");
            // 退出游戏
#if UNITY_EDITOR // 编辑器环境
            UnityEditor.EditorApplication.isPlaying = false;
#else //打包出来的环境下
            Application.Quit();
#endif
        }
    }
}
