using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using QFramework;

namespace SlayTheSpireM
{
    public class CharacterSelectView : View
    {
        [SerializeField] private Button returnBtn;
        [SerializeField] private Button embarkBtn;

        public override void Init()
        {
            PrepareInitialDeck();
            returnBtn.onClick.AddListener(() => ViewManager.ShowLast());
            embarkBtn.onClick.AddListener(() => SceneManager.LoadScene("MainScene"));
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
    }
}
