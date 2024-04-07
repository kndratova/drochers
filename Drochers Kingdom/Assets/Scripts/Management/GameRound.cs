using System;
using System.Collections.Generic;
using System.Linq;
using Game;
using ScriptableObjects.Cards;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

namespace Management
{
    public enum RoundState
    {
        CardPick,
        Building,
        PointsCount
    }
    public class GameRound : MonoBehaviour
    {
        [SerializeField] private int roundCount = 0;
        [SerializeField] private List<Player> players = new();
        private LinkedList<Player> _players;
    
        [SerializeField] private List<CardSO> allCardsStack;
        private int _readyPlayersCount;
        [SerializeField] private int useCardCount = 2;
        [SerializeField] private int discardCardCount = 0;

        public static RoundState RoundState { get; private set; }
        public static readonly UnityEvent RoundStateChanged = new();

        private void AutoPlay()
        {
            foreach (var player in _players.Where(player => !player.gameObject.CompareTag("Player")))
            {
                Debug.Log(player.playerColor);
                var playerCards = new List<CardSO>(player.playerCards);
                var card1 = playerCards[0];
                var card2 = playerCards[1];
                if (card1.GetType() == typeof(TerritoryCardSO))
                {
                    var territoryCard = (TerritoryCardSO)card1;
                    Field.TerritorySet.Invoke(player, territoryCard.coordinates);
                }
                if (card2.GetType() == typeof(TerritoryCardSO))
                {
                    var territoryCard = (TerritoryCardSO)card2;
                    Field.TerritorySet.Invoke(player, territoryCard.coordinates);
                }

                playerCards.Remove(card1);
                playerCards.Remove(card2);
            
                player.playerCards = new List<CardSO>(playerCards);
                player.playerCardsToGive = new List<CardSO>(playerCards);
            }
        }
        public void PlayerIsReady(Player player)
        {
            if (RoundState == RoundState.CardPick)
            {
                AutoPlay();
                _readyPlayersCount += _players.Count - 1;
                player.UpdateReadyCards();
            }

            if (RoundState == RoundState.Building)
            {
                _readyPlayersCount += _players.Count - 1;
            }
            _readyPlayersCount++;
            if (_readyPlayersCount != _players.Count) return;
        
            _readyPlayersCount = 0;
            switch (RoundState)
            {
                case RoundState.CardPick:
                    if (_players.First.Value.playerCards.Count == 0)
                    {
                        Debug.Log("HEY TS DONE");
                        RoundState = RoundState.Building;
                        RoundStateChanged.Invoke();
                    }
                    else
                    {
                        RotateCards();
                    }
                    break;
                case RoundState.Building:
                    if (roundCount < 4)
                    {
                        roundCount++;
                        RoundState = RoundState.CardPick;
                        GiveCards();
                        RoundStateChanged.Invoke();
                    }
                    else
                    {
                        RoundState = RoundState.PointsCount;
                        RoundStateChanged.Invoke();
                    }
                    break;
                case RoundState.PointsCount:
                    Debug.LogAssertion("GAME ENDED");
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void Start()
        {
            _players = new LinkedList<Player>(players);
            RoundState = RoundState.CardPick;
            GiveCards();
        }

        private void GiveCards()
        {
            var newPlayers = new List<Player>(_players);
            foreach (var player in newPlayers)
            {
                player.UpdatePlayerCards(new List<CardSO>(GiveNewCards(12)), useCardCount, discardCardCount);
            }
        }

        private IEnumerable<CardSO> GiveNewCards(int count)
        {
            var allStack = new List<CardSO>(allCardsStack);
            var newStack = new List<CardSO>();
        
            if (allStack.Count == 0)
            {
                Debug.LogWarning("No cards available in the stack.");
                return newStack;
            }
        
            count = Mathf.Min(count, allStack.Count);

            for (var i = 0; i < count; ++i)
            {
                var card = allStack[Random.Range(0, allStack.Count)];
                newStack.Add(card);
                allStack.Remove(card);
            }

            allCardsStack = new List<CardSO>(allStack);
            string CardsToGiveAsString = "";
            foreach (var cardSo in newStack)
            {
                CardsToGiveAsString += ", " + cardSo.Id.ToString();
            }
            Debug.Log("Cards to give: " + CardsToGiveAsString);
            return newStack;
        }
        private void RotateCards()
        {
            foreach (var player in _players)
            {
                var currentPlayerNode = _players.Find(player);
                if (currentPlayerNode == null) return;

                // Get the neighbor player based on the round count
                var neighborNode = (roundCount % 2 == 0) ? 
                    currentPlayerNode.Previous ?? _players.Last : 
                    currentPlayerNode.Next ?? _players.First;

                // Ensure neighborNode is not null
                if (neighborNode == null) return;
            
                neighborNode.Value.UpdatePlayerCards(new List<CardSO>(player.playerCardsToGive), useCardCount, discardCardCount);
                player.playerCardsToGive.Clear();
            }
        }

        public GameRound(LinkedList<Player> players)
        {
            _players = players;
        }
    }
}