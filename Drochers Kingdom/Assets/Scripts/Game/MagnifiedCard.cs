using Management;
using ScriptableObjects.Cards;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class MagnifiedCard : MonoBehaviour, IDisabledOnAwake
    {
        [SerializeField] private Image image;
    
        public void SetCard(CardSO card)
        {
            image.sprite = card.Sprite;
        }

        public void Initialize()
        {
            HoldCard.CardSelected.AddListener(SetCard);
        }
    }
}
