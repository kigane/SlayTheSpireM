using UnityEngine;
using UnityEngine.UI;
using QFramework;
using UnityEngine.SceneManagement;

namespace SlayTheSpireM
{
    public class CharacterSelectWindow : AQWindowController
    {
        [SerializeField] private Button returnBtn;
        [SerializeField] private Button embarkBtn;

        protected override void AddListeners()
        {
            returnBtn.onClick.AddListener(() => this.SendCommand<CloseCurrentScreenCommand>());
            embarkBtn.onClick.AddListener(() => SceneManager.LoadScene("MainScene"));
        }
    }
}
