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
            PrepareInitialDeck();
            startBtn.onClick.AddListener(() =>
            {
                Log.Debug("Start Game");
                startBtn.gameObject.SetActive(false);
                // this.SendCommand(new OpenNewScreenCommand(ScreenIds.ModeSelectWindow));
                SceneManager.LoadScene("MainScene");
            });
            exitBtn.onClick.AddListener(OnExit);
        }

        // 准备初始卡组
        private void PrepareInitialDeck()
        {
            IPlayerModel playerModel = this.GetModel<IPlayerModel>();
            CardDataBase cardDataBase = this.GetModel<CardDataBase>();
            playerModel.Deck.Add(new Card(cardDataBase.cards[0]));
            playerModel.Deck.Add(new Card(cardDataBase.cards[0]));
            playerModel.Deck.Add(new Card(cardDataBase.cards[0]));
            playerModel.Deck.Add(new Card(cardDataBase.cards[0]));
            playerModel.Deck.Add(new Card(cardDataBase.cards[0]));
            playerModel.Deck.Add(new Card(cardDataBase.cards[0]));
            playerModel.Deck.Add(new Card(cardDataBase.cards[1]));
            playerModel.Deck.Add(new Card(cardDataBase.cards[1]));
            playerModel.Deck.Add(new Card(cardDataBase.cards[1]));
            playerModel.Deck.Add(new Card(cardDataBase.cards[1]));
            playerModel.Deck.Add(new Card(cardDataBase.cards[1]));
            playerModel.Deck.Add(new Card(cardDataBase.cards[1]));
            playerModel.Deck.Add(new Card(cardDataBase.cards[2]));
            PlayerData.Instance.SetDeck(playerModel.Deck);
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
