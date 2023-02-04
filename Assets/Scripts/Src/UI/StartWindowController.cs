using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using deVoid.UIFramework;
using DG.Tweening;
using QFramework;

namespace SlayTheSpireM
{
    public class StartWindowController : AQWindowController
    {
        [SerializeField] private Button startBtn;
        [SerializeField] private Button exitBtn;

        protected override void AddListeners()
        {
            startBtn.onClick.AddListener(() =>
            {
                Log.Debug("Start Game");
                startBtn.gameObject.SetActive(false);
                exitBtn.gameObject.SetActive(false);
                // this.SendCommand(new OpenNewScreenCommand(ScreenIds.ModeSelectWindow));
                BattleSession.instance.CacheStartingDeck();
                SceneManager.LoadScene("MainScene");
            });
            exitBtn.onClick.AddListener(OnExit);
        }

        private void OnExit()
        {
            Log.Debug("quit");
            // 防止一个Dotween报错，原理不明。
            exitBtn.gameObject.SetActive(false);
            // Destroy(exitBtn); // 下一次update循环才起效
            // Destroy(GameObject.Find("[DOTween]"));

            // 退出游戏
#if UNITY_EDITOR // 编辑器环境
            UnityEditor.EditorApplication.isPlaying = false;
#else //打包出来的环境下
            Application.Quit();
#endif
        }
    }
}
