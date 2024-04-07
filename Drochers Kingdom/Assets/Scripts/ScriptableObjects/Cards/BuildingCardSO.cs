using UnityEngine;

namespace ScriptableObjects.Cards
{
    [CreateAssetMenu(menuName = "Card/Building Card")]
    public class BuildingCardSO : CardSO
    {
        [SerializeField] private BuildingSO building;
        public BuildingSO Building => building;
    }
}