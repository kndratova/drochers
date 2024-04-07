using Management;
using UnityEngine;

namespace Game
{
    public class CardHolder : MonoBehaviour, IDisabledOnAwake
    {
        [SerializeField] private Transform cardContainer;
        [SerializeField] private GameObject handCardPrefab;
    
        public void Initialize()
        {
            CardStack.CardStackSelected.AddListener(DisplayCards);
        }

        public void DisplayCards(CardStack cardStack)
        {
            var cards = cardStack.stackCards;
        
            foreach(Transform child in cardContainer)
            {
                Destroy(child.gameObject);
            }

            var instantiatePosition = Vector3.zero;
            foreach (var card in cards)
            {
                var handCard = Instantiate(handCardPrefab,
                        instantiatePosition,
                        Quaternion.identity,
                        cardContainer)
                    .GetComponent<HoldCard>();
                handCard.SetCard(card);
                instantiatePosition.z -= 0.1f;
            }
        
            gameObject.SetActive(true);
        }
    }
}
