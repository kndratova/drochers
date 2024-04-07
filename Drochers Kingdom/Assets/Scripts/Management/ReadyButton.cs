using System;
using Game;
using UnityEngine;
using UnityEngine.UI;

namespace Management
{
    public class ReadyButton : MonoBehaviour
    {
        [SerializeField] private Button readyButton;
        [SerializeField] private CardStack currentCardsStack;
        private void Start()
        {
            readyButton.interactable = false;
            currentCardsStack.cardStackUpdated.AddListener(CheckReadyButton);
            GameRound.RoundStateChanged.AddListener(CheckReadyButton);
        }

        private void CheckReadyButton()
        {
            switch (GameRound.RoundState)
            {
                case RoundState.CardPick:
                    readyButton.interactable = false;
                    readyButton.GetComponentInChildren<Text>().text = "Pick Ready!";
                    if (currentCardsStack.discardCount > 0) return;
                    if (currentCardsStack.useCount > 0) return;
                    readyButton.interactable = true;
                    break;
                case RoundState.Building:
                
                    readyButton.GetComponentInChildren<Text>().text = "Build Ready!";
                    readyButton.interactable = true;
                    break;
                case RoundState.PointsCount:
                    readyButton.interactable = false;
                    readyButton.GetComponentInChildren<Text>().text = "Congrats!";
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
