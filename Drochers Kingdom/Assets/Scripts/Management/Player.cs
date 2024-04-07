using System.Collections.Generic;
using Game;
using ScriptableObjects.Cards;
using UnityEngine;

namespace Management
{
    public class Player : MonoBehaviour
    {
        public CardStack currentCardsStack;
        public List<CardSO> playerCards = new();
        public List<CardSO> playerCardsToGive = new();
        public Color playerColor;

        private void Start()
        {
            if (currentCardsStack == null) return;
            currentCardsStack.cardStackUpdated.AddListener(UpdatePlayerCards);
        }

        private void UpdatePlayerCards()
        {
            playerCards = new List<CardSO>(currentCardsStack.stackCards);
        }

        public void UpdateReadyCards()
        {
            playerCardsToGive = new List<CardSO>(playerCards);
        }

        public void UpdatePlayerCards(IEnumerable<CardSO> newCards, int useCount, int discardCount)
        {
            playerCards = new List<CardSO>(newCards);
            if (currentCardsStack == null) return;
            currentCardsStack.useCount = useCount;
            currentCardsStack.discardCount = discardCount;
            currentCardsStack.stackCards = new List<CardSO>(playerCards);
            currentCardsStack.cardStackUpdated.Invoke();
        }
    }
}
