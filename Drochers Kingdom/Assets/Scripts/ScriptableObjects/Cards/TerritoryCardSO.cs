using UnityEngine;

namespace ScriptableObjects.Cards
{
    [CreateAssetMenu(menuName = "Card/Territory Card", fileName = "TerritoryCard")]
    public class TerritoryCardSO : CardSO
    {
        [SerializeField] public Vector2 coordinates;

        public Vector2 Coordinates => coordinates;
    }
}