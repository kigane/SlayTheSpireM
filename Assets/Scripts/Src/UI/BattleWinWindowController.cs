using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using deVoid.UIFramework;
using DG.Tweening;

namespace SlayTheSpireM
{
    public class BattleWinWindowController : AWindowController
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