using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace SlayTheSpireM
{
    public class Test : BaseController
    {
        IPlayerModel playerModel;

        private void Start()
        {
            playerModel = this.GetModel<IPlayerModel>();
            for (int i = 0; i < playerModel.Deck.Count; i++)
            {
                // Log.Debug(playerModel.Deck[i]);
            }
        }
    }
}
