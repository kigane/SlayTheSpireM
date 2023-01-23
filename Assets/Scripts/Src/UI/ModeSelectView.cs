using UnityEngine;
using UnityEngine.UI;

namespace SlayTheSpireM
{
    public class ModeSelectView : View
    {
        [SerializeField] private Button returnBtn;
        [SerializeField] private Button normalModeBtn;

        public override void Init()
        {
            returnBtn.onClick.AddListener(() => ViewManager.ShowLast());
            normalModeBtn.onClick.AddListener(() => ViewManager.Show<CharacterSelectView>(true));
        }
    }
}
