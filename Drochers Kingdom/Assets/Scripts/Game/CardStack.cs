using System.Collections.Generic;
using Management;
using ScriptableObjects.Cards;
using UnityEngine;
using UnityEngine.Events;

namespace Game
{
    public enum CardStackType
    {
        Current, 
        Discarded,
        Parchments,
        Buildings
    }
    public class CardStack : MonoBehaviour
    {
        [SerializeField] private CardSO[] allCards;
        [SerializeField] public List<CardSO> stackCards;
        [SerializeField] public CardStackType type;

        public Player TempPlayer;
        public int discardCount;
        public int useCount;
    
        public static readonly UnityEvent<CardStack> CardStackSelected = new();
        public UnityEvent cardStackUpdated;
        private static readonly UnityEvent<CardSO, CardStackType> CardAdd = new();
        private static readonly UnityEvent<CardSO, CardStackType> CardRemove = new();

        public void UseCard(CardStack stack, CardSO card)
        {
//        Debug.Log(nameof(UseCard));
            if (stack != this) return;
            var cardType = card.GetType();

            if (type == CardStackType.Buildings)
            {
                CardRemove.Invoke(card, CardStackType.Buildings);
                CardAdd.Invoke(card, CardStackType.Discarded);
            }
            if (type != CardStackType.Current) return;
            switch (cardType)
            {
                case var _ when cardType == typeof(TerritoryCardSO):
                    var territoryCard = (TerritoryCardSO)card;
                    Field.TerritorySet.Invoke(TempPlayer, territoryCard.coordinates);
                    break;
                case var _ when cardType == typeof(ParchmentCardSO):
                    CardAdd.Invoke(card, CardStackType.Parchments);
                    break;
                case var _ when cardType == typeof(ProvisionCardSO):
                    // Code to handle BuildingCardSO
                    break;
                case var _ when cardType == typeof(BuildingCardSO):
                    CardAdd.Invoke(card, CardStackType.Buildings);
                    break;
            }
            CardRemove.Invoke(card, CardStackType.Current);
        }

        public void DiscardCard(CardSO card)
        {
            CardAdd.Invoke(card, CardStackType.Discarded);
            CardRemove.Invoke(card, CardStackType.Current);
        }

        private void Start()
        {
            CardAdd.AddListener(AddCard);
            CardRemove.AddListener(RemoveCard);
        }

        private void RemoveCard(CardSO card, CardStackType stackType)
        {
            if (stackType != type) return;
            stackCards.Remove(card);
            cardStackUpdated.Invoke();
        }
        private void AddCard(CardSO card, CardStackType stackType)
        {
            if (stackType != type) return;
            stackCards.Add(card);
            cardStackUpdated.Invoke();
        }

        private void OnMouseDown()
        {
            if (stackCards.Count <= 0) return;
            CardStackSelected.Invoke(this);
        }
    }
}