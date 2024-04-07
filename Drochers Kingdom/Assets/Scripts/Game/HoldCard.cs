using ScriptableObjects.Cards;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Game
{
    public class HoldCard : MonoBehaviour
    {
        [SerializeField] private Vector2 shift;
        private CardSO _card;
        [SerializeField] private Image image;
        public static readonly UnityEvent<CardSO> CardSelected = new();
    
        private Transform _transform;
        private Vector3 _initialPosition;
        private Vector3 _shiftedPosition;

        private void Start()
        {
            _transform = transform;
        }

        public void SetCard(CardSO card)
        {
            _card = card;
            image.sprite = card.Sprite;
            CardSelected.Invoke(_card);
        }
    
        private void OnMouseDown()
        {
            CardSelected.Invoke(_card);
        }
    }
}
