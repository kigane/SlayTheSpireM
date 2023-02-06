using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using deVoid.UIFramework;
using QFramework;
using DG.Tweening;

namespace SlayTheSpireM
{
    public class GameOverWindow : AQWindowController
    {
        [SerializeField] Button returnToTitle;
        protected override void AddListeners()
        {
            returnToTitle.onClick.AddListener(() =>
            {
                SceneManager.LoadScene("StartScene");
            });
        }
    }
}