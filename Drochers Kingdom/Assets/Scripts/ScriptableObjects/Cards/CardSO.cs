using UnityEngine;

namespace ScriptableObjects.Cards
{
    public class CardSO : ScriptableObject
    {
        [SerializeField] private int id;
        [SerializeField] private Sprite sprite;
        [SerializeField] private string description;
    
        public Sprite Sprite => sprite;
        public string Description => description;
        public int Id => id;
    }
}
