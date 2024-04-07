using System;
using Management;
using ScriptableObjects.Cards;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class CardButtons : MonoBehaviour, IDisabledOnAwake
    {
        [SerializeField] private Button useButton;
        [SerializeField] private Button discardButton;
        [SerializeField] private Button buildButton;
    
        private CardStack _cardStack;
        private CardSO _card;
        private void CheckButtons(CardStack cardStack)
        {
            _cardStack = cardStack;
        
            useButton.gameObject.SetActive(false);
            discardButton.gameObject.SetActive(false);
            buildButton.gameObject.SetActive(false);
        
            switch (GameRound.RoundState)
            {
                case RoundState.CardPick:
                    useButton.gameObject.SetActive(_cardStack.useCount != 0);
                    useButton.GetComponentInChildren<Text>().text = "Use (" + _cardStack.useCount + ")";
                    discardButton.gameObject.SetActive(_cardStack.discardCount != 0);
                    discardButton.GetComponentInChildren<Text>().text = "Discard (" + _cardStack.discardCount + ")"; 
                    break;
                case RoundState.Building:
                    if (_cardStack.type == CardStackType.Buildings) buildButton.gameObject.SetActive(true);
                    break;
                case RoundState.PointsCount:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }


        private void SetCard(CardSO card)
        {
            _card = card;
        }
        private void UseCard()
        {
            _cardStack.useCount -= 1;
            _cardStack.UseCard(_cardStack, _card);
            CheckButtons(_cardStack);
        }

        private void DiscardCard()
        {
            _cardStack.discardCount -= 1;
            _cardStack.DiscardCard(_card);
            CheckButtons(_cardStack);
        }


        public void Build()
        {
            var card = (BuildingCardSO)_card;
            Builder.BuildCardSelected.Invoke(card);
        }

        public void Initialize()
        {
            CardStack.CardStackSelected.AddListener(CheckButtons);
            HoldCard.CardSelected.AddListener(SetCard);
            useButton.onClick.AddListener(UseCard);
            discardButton.onClick.AddListener(DiscardCard);
        }
    }
}
