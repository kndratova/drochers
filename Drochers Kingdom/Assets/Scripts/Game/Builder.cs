using ScriptableObjects.Cards;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Game
{
    public class Builder : MonoBehaviour
    {
        public static readonly UnityEvent<BuildingCardSO> BuildCardSelected = new();
        [SerializeField] private Image image;
        [SerializeField] private Button button;
        [SerializeField] private CardStack cardStack;

        private BuildingCardSO _card;
        private Field _field;
    
        private void Start()
        {
            _field = FindObjectOfType<Field>();
            CardStack.CardStackSelected.AddListener(HideBuildItems);
            BuildCardSelected.AddListener(DisplayBuildItems);
        }

        public void HideBuildItems(CardStack _)
        {
            _card = null;
            image.gameObject.SetActive(false);
            button.gameObject.SetActive(false);
        }
    
        private void DisplayBuildItems(BuildingCardSO card)
        {
            _card = card;
            image.sprite = _card.Building.Sprite;
            image.gameObject.SetActive(true);
            button.gameObject.SetActive(true);
        }

        public void Build()
        {
            _field.Build(_card.Building);
            cardStack.UseCard(cardStack, _card);
            HideBuildItems(cardStack);
        }
    }
}
