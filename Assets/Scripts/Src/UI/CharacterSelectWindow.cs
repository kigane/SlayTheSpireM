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
            PrepareInitialDeck();
            returnBtn.onClick.AddListener(() => this.SendCommand<CloseCurrentScreenCommand>());
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